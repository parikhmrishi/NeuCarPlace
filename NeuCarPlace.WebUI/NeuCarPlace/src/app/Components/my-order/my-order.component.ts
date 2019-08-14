import { Component, OnInit } from "@angular/core";
import { CarsService } from "src/app/Services/cars.service";
import { OrderService } from "src/app/Services/order.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-my-order",
  templateUrl: "./my-order.component.html",
  styleUrls: ["./my-order.component.scss"]
})
export class MyOrderComponent implements OnInit {
  show: boolean = false;
  cars: any;
  constructor(private orderService: OrderService, private router: Router) {}

  ngOnInit() {
    this.orderService
      .getOrders(localStorage.getItem("email"))
      .subscribe(cars => {
        this.cars = cars;
        this.show = true;
      },
      error => {
        this.show = false;
      });
  }
  carDetails(car) {
    this.router.navigate(["myorders/" + car.carId]);
  }
}
