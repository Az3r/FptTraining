import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IProductDetail, IProductMaster } from '../shared/product';
import { stringify } from 'qs'
import { catchError } from 'rxjs/operators'
import { of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly url = `${environment.apiUrl}/product`;

  constructor(private http: HttpClient) { }

  findProducts(query: FindProductQuery) {
    const querify = stringify({
      ...query,
      order: query?.order && Object.entries(query.order)
        .map(([key, value]) => `${key}(${value})`)
        .join(',')
    }, { skipNulls: true })

    return this.http.get<IProductMaster>(`${this.url}?${querify}`)
      .pipe(catchError((err) => this.onError("findProducts", err)));
  }

  getProduct(id: string) {
    return this.http.get<IProductDetail>(`${this.url}/${id}`)
      .pipe<IProductDetail | undefined>(
        catchError((err) => this.onError<IProductDetail>("getProduct", err))
      );
  }

  updateProduct(id: string, data: Omit<IProductDetail, "id">) {
    return this.http.put<IProductDetail>(`${this.url}/update/${id}`, data)
      .pipe(catchError((err) => this.onError("updateProduct", err)));
  }

  deleteProduct(id: string) {
    return this.http.delete(`${this.url}/delete/${id}`)
      .pipe(catchError((err) => this.onError("deleteProduct", err)));
  }

  onError<T>(operation: string, error: any, fallback?: T) {
    console.error(operation, error)
    if (fallback == undefined) throwError(error)
    return of(fallback);
  }
}

export interface FindProductQuery {
  name?: string,
  category?: string,
  minPrice?: number,
  maxPrice?: number
  size?: number,
  offset?: number,
  order?: {
    [field: string]: 'asc' | 'desc'
  }
}
