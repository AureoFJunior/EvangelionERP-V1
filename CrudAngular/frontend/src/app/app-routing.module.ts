import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './views/home/home.component'
import { ProductCrudComponent } from './views/product-crud/product-crud.component'
import { ProductCreateComponent } from './componentes/product/product-create/product-create.component'
import { ProductUpdateComponent } from './componentes/product/product-update/product-update.component'
import { EmployerCrudComponent } from './views/employer-crud/employer-crud.component';
import { EmployerCreateComponent } from './componentes/employer/employer-create/employer-create.component';
import { EmployerUpdateComponent } from './componentes/employer/employer-update/employer-update.component';
import { EmployerReadComponent } from './componentes/employer/employer-read/employer-read.component';
import { LoginScreenComponent } from './views/login-screen/login-screen.component';
import { SignupScreenComponent } from './views/signup-screen/signup-screen.component';
import { ProfileComponent } from './views/profile/profile.component';
import { ShowcaseComponent } from './views/showcase/showcase.component';
import { AuthGuardService } from './services/guard/auth-guard.service';
import { OrderCrudComponent } from './views/order-crud/order-crud.component';
import { OrderCreateComponent } from './componentes/order/order-create/order-create.component';
import { OrderUpdateComponent } from './componentes/order/order-update/order-update.component';

//Rotas da minha aplicação
const routes: Routes = [
  {
    path: "",
    component: LoginScreenComponent
  },
  {
    path: "signup",
    component: SignupScreenComponent
  },
  {
    path: "showcase",
    component: ShowcaseComponent,
    canActivate: [AuthGuardService]

  },
  {
    path: "profile",
    component: ProfileComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "home",
    component: HomeComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "products",
    component: ProductCrudComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "products/create",
    component: ProductCreateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "products/update/:id",
    component: ProductUpdateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "products/:id",
    component: ProductCrudComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "employers",
    component: EmployerCrudComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "employers/create",
    component: EmployerCreateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "employers/update/:cod",
    component: EmployerUpdateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "employers/:cod",
    component: EmployerCrudComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "orders",
    component: OrderCrudComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "orders/create",
    component: OrderCreateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "orders/update/:id/:status",
    component: OrderUpdateComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: "orders/:id",
    component: OrderCrudComponent,
    canActivate: [AuthGuardService]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
