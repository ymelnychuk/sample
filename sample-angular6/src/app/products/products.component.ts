import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.productService.getAllProducts()
      .subscribe(product => {
        console.table(product);
        this.products = product as Product[]
      });
  }
}
