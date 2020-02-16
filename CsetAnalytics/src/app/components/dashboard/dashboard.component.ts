import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  multi: any[] =[ 
    {
      "name": "Industry", 
      "series": [{
        "name": "Yes",
        "value": 197
        },
        {
          "name": "No",
          "value": 100
        },
        {
          "name": "Unanswered",
          "value": 58
        }
      ]
    },
    {
      "name": "Sector", 
      "series": [{
        "name": "Yes",
        "value": 235
        },
        {
          "name": "No",
          "value": 87
        },
        {
          "name": "Unanswered",
          "value": 28
        }
      ]
    },
    {
      "name": "My Data", 
      "series": [{
        "name": "Yes",
        "value": 168
        },
        {
          "name": "No",
          "value": 72
        },
        {
          "name": "Unanswered",
          "value": 110
        }
      ]
    }
  ];
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

  constructor() { 
    Object.assign(this, this.multi);
  }

  ngOnInit() {
  }
  
  onSelect(event){
    console.log(event);
  }
}
