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

  async findProducts(query: IFindProductQuery): Promise<IPaginationResponse<IProductMaster>> {
    const querify = stringify({
      ...query,
      sort: query?.sort && Object.entries(query.sort)
        .map(([key, value]) => `${key}:${value}`)
    }, { skipNulls: true, arrayFormat: 'comma' })

    return this.http.get<IPaginationResponse<IProductMaster>>(`${this.url}?${querify}`)
      .pipe(
        catchError(err => this.onError<IPaginationResponse<IProductMaster>>("findProducts", err))
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

  async updateProduct(id: string, data: IUpdateProductRequest): Promise<void> {
    // make sure we are using utc time here
    if (typeof data.releasedDate !== 'string')
      data.releasedDate = data.releasedDate.toISOString()
    if (data.discontinuedDate && typeof data.discontinuedDate !== 'string')
      data.discontinuedDate = data.discontinuedDate.toISOString()
    console.log(data)

    return this.http.put<void>(`${this.url}/${id}`, data)
      .pipe(catchError((err) => this.onError<void>("updateProduct", err)))
      .toPromise();
  }

  async deleteProduct(id: string): Promise<void> {
    return this.http.delete<void>(`${this.url}/${id}`)
      .pipe(catchError((err) => this.onError<void>("deleteProduct", err)))
      .toPromise();
  }

  async createProduct(request: ICreateProductRequest): Promise<IProductDetail> {
    // make sure we are using utc time here
    if (typeof request.releasedDate !== 'string')
      request.releasedDate = request.releasedDate.toISOString()

    return this.http.post<IProductDetail>(`${this.url}`, request)
      .pipe(catchError((err) => this.onError<IProductDetail>("createProduct", err)))
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

export interface IFindProductQuery {
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

export interface IPaginationResponse<T> {
  items: T[],
  totalPages: number,
  pageSize: number,
  pageOffset: number
}

export interface ICreateProductRequest {
  name: string,
  description: string,
  categoryIds: string[],
  supplierId: string,
  price: number,
  releasedDate: Date | string
}

export interface IUpdateProductRequest extends ICreateProductRequest {
  detail: string,
  discontinuedDate?: Date | string
}