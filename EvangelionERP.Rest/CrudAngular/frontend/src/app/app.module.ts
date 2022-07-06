import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { HomeComponent } from './views/home/home.component';
import { ProductCrudComponent } from './views/product-crud/product-crud.component';
import { RedDirective } from './directives/red.directive';
import { ProductCreateComponent } from './componentes/product/product-create/product-create.component';

import { HttpClientModule } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ProductReadComponent } from './componentes/product/product-read/product-read.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ProductUpdateComponent } from './componentes/product/product-update/product-update.component';
import { EmployerCrudComponent } from './views/employer-crud/employer-crud.component';
import { EmployerCreateComponent } from './componentes/employer/employer-create/employer-create.component';
import { EmployerUpdateComponent } from './componentes/employer/employer-update/employer-update.component';
import { EmployerReadComponent } from './componentes/employer/employer-read/employer-read.component';

import { FooterComponent } from './componentes/templates/footer/footer.component';
import { NavComponent } from './componentes/templates/nav/nav.component';
import { MatRadioModule } from '@angular/material/radio';
import { LoginScreenComponent } from './views/login-screen/login-screen.component';
import { SignupScreenComponent } from './views/signup-screen/signup-screen.component';
import { UserReadComponent } from './componentes/user/user-read/user-read.component';
import { MatIconModule } from '@angular/material/icon';
import { NgxMaskModule } from 'ngx-mask';
import { ProfileComponent } from './views/profile/profile.component';
import { ShowcaseComponent } from './views/showcase/showcase.component';
import { UserService } from './componentes/user/user.service';
import { AuthGuardService } from './services/guard/auth-guard.service';
import { OrderCreateComponent } from './componentes/order/order-create/order-create.component';
import { OrderReadComponent } from './componentes/order/order-read/order-read.component';
import { OrderUpdateComponent } from './componentes/order/order-update/order-update.component';
import { OrderCrudComponent } from './views/order-crud/order-crud.component';
import { CommonModule } from '@angular/common';
import { NgImageSliderModule } from 'ng-image-slider';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import ptBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';

registerLocaleData(ptBr);

@NgModule({
	declarations: [
		AppComponent,
		FooterComponent,
		NavComponent,
		HomeComponent,
		ProductCrudComponent,
		RedDirective,
		ProductCreateComponent,
		ProductReadComponent,
		ProductUpdateComponent,
		EmployerCrudComponent,
		EmployerCreateComponent,
		EmployerUpdateComponent,
		EmployerReadComponent,
		LoginScreenComponent,
		SignupScreenComponent,
		UserReadComponent,
		ProfileComponent,
		ShowcaseComponent,
		OrderCreateComponent,
		OrderReadComponent,
		OrderUpdateComponent,
		OrderCrudComponent,
		DashboardComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		BrowserAnimationsModule,
		MatToolbarModule,
		MatSidenavModule,
		MatListModule,
		MatCardModule,
		MatButtonModule,
		MatSnackBarModule,
		HttpClientModule,
		FormsModule,
		MatFormFieldModule,
		MatInputModule,
		MatTableModule,
		MatPaginatorModule,
		MatSortModule,
		MatRadioModule,
		MatIconModule,
		ReactiveFormsModule,
		CommonModule,
		NgImageSliderModule,
		NgxMaskModule.forRoot()

	],
	providers: [UserService, AuthGuardService, { provide: LOCALE_ID, useValue: 'pt' }],
	bootstrap: [AppComponent]
})
export class AppModule {
}
