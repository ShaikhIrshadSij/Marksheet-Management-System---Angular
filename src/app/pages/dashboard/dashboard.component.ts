import { Component, OnInit, ViewChild } from '@angular/core';
import { DashboardService } from 'src/app/core/dashboard/dashboard.service';
import { DashboardOverView } from 'src/app/core/_models/dashboardoverview';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  departmentList = ["Automobile", "Civil", "Computer", "EC", "Electrical", "Mechanical"];
  @ViewChild('ddlYear') filterYear;
  @ViewChild('ddlSemester') filterSemester;
  overViewData = new DashboardOverView();

  constructor(private _dashboardService: DashboardService) { }

  ngOnInit() {
    this.getDashboardOverView();
  }

  getDashboardOverView() {
    var overviewList: any;
    overviewList = this._dashboardService.getDashboardOverView(this.filterYear.nativeElement.value, this.filterSemester.nativeElement.value)
      .subscribe(res => {
        var response: any = res;
        overviewList = response.data;
        this.overViewData = new DashboardOverView();
        for (var i = 0; i < overviewList.length; i++) {
          switch (overviewList[i]["Department"]) {
            case this.departmentList[0]:
              this.overViewData.AutomobileIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.AutomobileUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
            case this.departmentList[1]:
              this.overViewData.CivilIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.CivilUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
            case this.departmentList[2]:
              this.overViewData.ComputerIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.ComputerUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
            case this.departmentList[3]:
              this.overViewData.ECIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.ECUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
            case this.departmentList[4]:
              this.overViewData.ElectricalIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.ElectricalUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
            case this.departmentList[5]:
              this.overViewData.MechanicalIssuedMarksheet = overviewList[i]["IssuedMarksheet"];
              this.overViewData.MechanicalUnIssuedMarksheet = overviewList[i]["UnIssuedMarksheet"];
              break;
          }
        }
      });
  }

}
