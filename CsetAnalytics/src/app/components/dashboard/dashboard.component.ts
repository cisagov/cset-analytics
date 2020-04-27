import { Component, OnInit } from '@angular/core';
import { DashboardService } from './dashboard.service';
import { assertNotNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  view: any[] = [700, 400]

  showXAxis: boolean = true;
  showYAxis: boolean = true;
  gradient: boolean = false;
  showLegend: boolean = true;
  showXAxisLabel: boolean = true;
  yAxisLabel: string = '';
  showYAxisLabel: boolean = true;
  xAxisLabel: string = '';

  colorScheme = {
    domain: ['#5AA454', '#C7B42C', '#AAAAAA']
  };

  dashboardData: any;
  data: any;
  displayedColumns: string[] = ['assessment_Id', 'alias', 'assessmentCreatedDate', 'lastAccessedDate'];
  Assessment_Id: number;
  constructor(private dashboardService: DashboardService) { 
    //Object.assign(this, this.multi);
  }

  ngOnInit() {        
    this.getAssessmentData();
  }
  
  getAssessmentData() {
    this.dashboardService.getAssessmentsForUser("Barry2").subscribe((data: any)=>{
      this.data= data;      
      
    });
  }
  
  getDashboardData(Assessment_Id:number){
    this.dashboardService.getDashboard(Assessment_Id).subscribe((data:any)=>{        
        this.dashboardData = data;
      }      
    );
  }

  setRecord(item: any){
    console.log(item);
    this.getDashboardData(item.assessment_Id);
  }

  onSelect(event){
    console.log(event);
  }
}
