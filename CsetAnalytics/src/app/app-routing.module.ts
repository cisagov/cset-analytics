import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutBlankComponent } from './components/layout/layout-blank/layout-blank.component';
import { AuthGuard } from './auth/authGuard';
import { LoginComponent } from './components/login/login.component'
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {
    path:'login', component: LayoutBlankComponent,
    children: [
      { path: '', component: LoginComponent}
    ]
  },
  {
    path:'dashboard', component: LayoutBlankComponent, canActivate: [AuthGuard], 
    children: [
      { path: '', component: DashboardComponent}
    ]
  },
  {
    path:'', component: LayoutBlankComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: DashboardComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
