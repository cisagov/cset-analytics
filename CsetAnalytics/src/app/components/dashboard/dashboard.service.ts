import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { share } from "rxjs/operators";

@Injectable()

export class DashboardService {

  constructor(private http: HttpClient, private router: Router) {

  }
}
