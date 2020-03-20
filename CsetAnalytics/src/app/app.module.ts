import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/token.interceptor';
import { AuthGuard } from './auth/authGuard';
import { CovalentLayoutModule } from '@covalent/core/layout';
import { CovalentStepsModule  } from '@covalent/core/steps';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { LoginService } from './components/login/login.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutBlankComponent } from './components/layout/layout-blank/layout-blank.component';
import { LayoutMainComponent } from './components/layout/layout-main/layout-main.component';

import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardService } from './components/dashboard/dashboard.service';
import { DataTableModule } from 'ng-angular8-datatable';

@NgModule({
  declarations: [
    AppComponent, 
    LoginComponent, 
    DashboardComponent,
    LayoutBlankComponent,
    LayoutMainComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, 
    CommonModule, 
    HttpClientModule, 
    FormsModule, 
    ReactiveFormsModule, 
    MaterialModule, 
    CovalentLayoutModule, 
    CovalentStepsModule, 
    NgxChartsModule,
    DataTableModule
  ],
  providers: [
    LoginService,
    DashboardService, 
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS, 
      useClass: AuthInterceptor, 
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
