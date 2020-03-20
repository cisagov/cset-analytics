import { Component, OnInit } from '@angular/core';
import { DashboardService } from './dashboard.service';
import { assertNotNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  // multi: any[] =[ 
  //   {
  //     "name": "Industry", 
  //     "series": [{
  //       "name": "Yes",
  //       "value": 197
  //       },
  //       {
  //         "name": "No",
  //         "value": 100
  //       },
  //       {
  //         "name": "Unanswered",
  //         "value": 58
  //       }
  //     ]
  //   },
  //   {
  //     "name": "Sector", 
  //     "series": [{
  //       "name": "Yes",
  //       "value": 235
  //       },
  //       {
  //         "name": "No",
  //         "value": 87
  //       },
  //       {
  //         "name": "Unanswered",
  //         "value": 28
  //       }
  //     ]
  //   },
  //   {
  //     "name": "My Data", 
  //     "series": [{
  //       "name": "Yes",
  //       "value": 168
  //       },
  //       {
  //         "name": "No",
  //         "value": 72
  //       },
  //       {
  //         "name": "Unanswered",
  //         "value": 110
  //       }
  //     ]
  //   }
  // ];
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
  Assessment_Id: number;
  constructor(private dashboardService: DashboardService) { 
    //Object.assign(this, this.multi);
  }

  ngOnInit() {    
    //this.getDashboardData(2);
    this.getAssessmentData();
  }
  getAssessmentData() {
    this.dashboardService.getAssessmentsForUser("Barry2").subscribe((data: any)=>{
      this.data= data;      
      
    });
  }
  
  getDashboardData(Assessment_Id:number){
    this.dashboardService.getDashboard(Assessment_Id).subscribe((data:any)=>{
        console.log("this is the data");
        console.log(data);
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
