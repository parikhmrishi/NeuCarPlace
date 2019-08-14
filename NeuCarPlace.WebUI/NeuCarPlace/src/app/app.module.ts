import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./Components/login/login.component";
import { HttpClientModule } from "@angular/common/http";
import { UserService } from "./Services/user.service";
import { CarDetailComponent } from "./Components/car-detail/car-detail.component";
import { HeaderComponent } from "./Components/header/header.component";
import { HomeComponent } from "./Components/home/home.component";
import { SummaryComponent } from "./Components/car-detail/summary/summary.component";
import { MyOrderComponent } from "./Components/my-order/my-order.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CarDetailComponent,
    HeaderComponent,
    HomeComponent,
    SummaryComponent,
    MyOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
