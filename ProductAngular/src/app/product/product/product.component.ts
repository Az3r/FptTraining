import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.sass']
})
export class ProductComponent implements OnInit {

  products = [
    {
      "id": "61404b9cbac916e34cfb4e21",
      "name": "deserunt duis cillum eu aliqua veniam eiusmod pariatur ea quis",
      "price": 74.07,
      "rating": 2.19,
      "category": "nulla ipsum excepteur",
      "supplier": "amet"
    },
    {
      "id": "61404b9cc8f5763337a93eb7",
      "name": "dolore occaecat velit",
      "price": 39.56,
      "rating": 2.63,
      "category": "esse qui sint commodo nostrud aliqua ipsum sunt",
      "supplier": "nostrud consequat laborum"
    },
    {
      "id": "61404b9c7caca90e301f83f2",
      "name": "reprehenderit aliquip eiusmod in irure aute Lorem",
      "price": 85.92,
      "rating": 3.28,
      "category": "ullamco voluptate consequat nisi irure officia",
      "supplier": "mollit exercitation anim ad esse magna do non irure ea"
    },
    {
      "id": "61404b9c006e1b1503797be5",
      "name": "proident deserunt dolore aliqua sit cupidatat labore veniam commodo cillum",
      "price": 97.48,
      "rating": 3.16,
      "category": "aliqua",
      "supplier": "ex cillum ad qui nisi ut minim"
    },
    {
      "id": "61404b9cdc9a8acd3700a7ff",
      "name": "consequat consequat nulla culpa amet qui",
      "price": 66.72,
      "rating": 4.22,
      "category": "Lorem elit cupidatat est aliquip",
      "supplier": "quis sit veniam est culpa nisi Lorem"
    },
    {
      "id": "61404b9c3be5d9afdb1f1440",
      "name": "incididunt reprehenderit dolore esse aliquip deserunt laborum",
      "price": 36.59,
      "rating": 1.57,
      "category": "nisi adipisicing qui",
      "supplier": "ex"
    },
    {
      "id": "61404b9c8ea4547c9d32ad8e",
      "name": "et voluptate anim sunt",
      "price": 38.27,
      "rating": 3.07,
      "category": "ad",
      "supplier": "esse deserunt nostrud nostrud id"
    },
    {
      "id": "61404b9cb3844d69a4cedaca",
      "name": "amet commodo aliqua pariatur veniam fugiat ex",
      "price": 5.68,
      "rating": 1.63,
      "category": "laborum et excepteur exercitation duis incididunt voluptate sunt est",
      "supplier": "cillum nisi veniam ut aliqua consectetur labore nulla laborum anim"
    },
    {
      "id": "61404b9c1f6d94a8cf694d4a",
      "name": "occaecat in quis ullamco id ipsum",
      "price": 17.19,
      "rating": 4.14,
      "category": "laboris eu nulla dolor fugiat incididunt consequat consequat proident",
      "supplier": "consectetur"
    },
    {
      "id": "61404b9cab7a87b65ee40db2",
      "name": "tempor laborum occaecat minim non pariatur",
      "price": 22.32,
      "rating": 2.54,
      "category": "deserunt non esse reprehenderit ad incididunt sit exercitation reprehenderit sint",
      "supplier": "Lorem fugiat ut ut occaecat sunt ad tempor do est"
    }
  ]

  columns: string[] = ["name", "supplier", "category", "price", "rating"]



  constructor() { }

  ngOnInit(): void {
  }

}
