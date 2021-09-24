export interface IProductMaster {
  id: string,
  name: string,
  price: number,
  rating: number,
  categories: string[],
  supplier: string,
  description: string,
}

export interface IProductDetail extends IProductMaster {
  detail: string
  releasedDate: Date,
  discontinuedAt?: Date,
}
