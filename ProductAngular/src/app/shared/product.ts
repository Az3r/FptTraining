export interface IProductMaster {
  id: string,
  name: string,
  price: number,
  rating: number,
  category: string,
  supplier: string,
  description: string,
}

export interface IProductDetail extends IProductMaster {
  detail: string
  releasedAt: Date,
  discontinuedAt?: Date,
}