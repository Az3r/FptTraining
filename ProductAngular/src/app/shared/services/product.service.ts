import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICategory, IProductDetail, IProductMaster, ISupplier } from 'src/app/shared/models/product';
import { stringify } from 'qs'
import { catchError } from 'rxjs/operators'
import { Observable, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly url = `${environment.apiUrl}/product`;

  constructor(private http: HttpClient) { }

  async findProducts(query: FindProductQuery): Promise<PaginationResponse<IProductMaster>> {
    const querify = stringify({
      ...query,
      sort: query?.sort && Object.entries(query.sort)
        .map(([key, value]) => `${key}:${value}`)
    }, { skipNulls: true, arrayFormat: 'comma' })

    return this.http.get<PaginationResponse<IProductMaster>>(`${this.url}?${querify}`)
      .pipe(
        catchError(err => this.onError<PaginationResponse<IProductMaster>>("findProducts", err))
      )
      .toPromise();
  }

  async getProduct(id: string): Promise<IProductDetail> {
    return this.http.get<IProductDetail>(`${this.url}/${id}`)
      .pipe(
        catchError((err) => this.onError<IProductDetail>("getProduct", err))
      )
      .toPromise();
  }

  async updateProduct(id: string, data: Omit<IProductDetail, "id">): Promise<void> {
    return this.http.put<void>(`${this.url}/update/${id}`, data)
      .pipe(catchError((err) => this.onError<void>("updateProduct", err)))
      .toPromise();
  }

  deleteProduct(id: string): Promise<void> {
    return this.http.delete<void>(`${this.url}/delete/${id}`)
      .pipe(catchError((err) => this.onError<void>("deleteProduct", err)))
      .toPromise();
  }

  async getCategories(): Promise<ICategory[]> {
    return this.http.get<ICategory[]>(`${environment.apiUrl}/category/all`)
      .pipe(
        catchError((err) => this.onError<ICategory[]>("getCategories", err))
      )
      .toPromise();
  }

  async getSuppliers() {
    return this.http.get<ISupplier[]>(`${environment.apiUrl}/supplier/all`)
      .pipe(
        catchError((err) => this.onError<ISupplier[]>("getCategories", err))
      )
      .toPromise();
  }

  onError<T>(operation: string, error: HttpErrorResponse, fallback?: T): Observable<T> {
    console.error(operation, error)
    if (fallback == undefined) return throwError(error)
    else return of(fallback);
  }
}

export interface FindProductQuery {
  name?: string,
  categories?: string[],
  minPrice?: number,
  maxPrice?: number
  size?: number,
  offset?: number,
  sort?: {
    [field: string]: 'asc' | 'desc'
  }
}

export interface PaginationResponse<T> {
  items: T[],
  totalPages: number,
  pageSize: number,
  pageOffset: number
}
