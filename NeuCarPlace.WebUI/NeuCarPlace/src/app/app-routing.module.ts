import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { CarDetailComponent } from './Components/car-detail/car-detail.component';
import { SummaryComponent } from "./Components/car-detail/summary/summary.component";
import { HomeComponent } from './Components/home/home.component';
import { MyOrderComponent } from './Components/my-order/my-order.component';
import { AuthService } from './Services/auth.service'

const routes: Routes = [
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: 'login',component: LoginComponent },
  { path: 'cardetail/:id',component: CarDetailComponent, canActivate: [AuthService] },
  { path: 'myorders/:id',component: CarDetailComponent, canActivate: [AuthService] },
  { path: 'summary/:id',component: SummaryComponent, canActivate: [AuthService] },
  { path: 'home',component: HomeComponent },
  { path: 'myorders',component: MyOrderComponent, canActivate: [AuthService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
