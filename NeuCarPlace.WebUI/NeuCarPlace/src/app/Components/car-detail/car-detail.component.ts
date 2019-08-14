import { Component, OnInit } from "@angular/core";
import { CarsService } from "src/app/Services/cars.service";
import { ActivatedRoute, Router } from "@angular/router";
import { OrderService } from "src/app/Services/order.service";

@Component({
  selector: "app-car-detail",
  templateUrl: "./car-detail.component.html",
  styleUrls: ["./car-detail.component.scss"]
})
export class CarDetailComponent implements OnInit {
  carId: number;
  carDetail: any;
  show: boolean = false;
  checkBooking: any = false;
  constructor(
    private carsService: CarsService,
    private route: ActivatedRoute,
    private orderService: OrderService,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);

      this.carId = params["id"];
      this.carsService.getCar(this.carId).subscribe(data => {
        console.log(data);
        this.carDetail = data;
        this.show = true;
      });

      this.bookingDetail();
    });
  }

  bookingDetail() {
    this.orderService
      .checkBooking(localStorage.getItem("email"), this.carId)
      .subscribe(booking => (this.checkBooking = booking));
  }

  summary() {
    this.router.navigate(['summary/'+this.carId])
  }

  cancelBooking() {
    this.orderService
      .cancelBooking(localStorage.getItem("email"), this.carId)
      .subscribe(() => {
        this.bookingDetail();
      });
  }

}
