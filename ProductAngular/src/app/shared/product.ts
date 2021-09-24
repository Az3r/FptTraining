export interface IProductMaster {
  id: string,
  name: string,
  price: number,
  rating: number,
  categories: string[],
  supplier: string,
  description: string,
}

export interface IProductDetail {
  id: string,
  name: string,
  price: number,
  rating: number,
  categories: ICategory[],
  supplier: ISupplier,
  description: string,
  detail: string
  releasedDate: Date,
  discontinuedDate?: Date,
}

export interface ICategory {
  id: string,
  name: string
}

export interface ISupplier {
  id: string,
  name: string
}