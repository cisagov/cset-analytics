import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";

@Injectable()
export class DashboardService {
  
  private apiUrl: string;
  constructor(private http: HttpClient, private router: Router) {
    this.apiUrl = 'https://localhost:44397/api/';
  }

  getDashboard(assessment_id:number) {
    return this.http.get(this.apiUrl + 'Dashboard/GetDashboardChart?assessment_id='+assessment_id);
  }

  getAssessmentsForUser(arg0: string) {
    return this.http.get(this.apiUrl + 'Dashboard/GetAssessmentList');
  }

}
