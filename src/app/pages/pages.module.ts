import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PagesRoutingModule } from './pages-routing.module';
import { MatchHeightModule } from '../shared/directives/match-height.directive';
import { MarksheetComponent } from './uploads/marksheet/marksheet.component';
import { MarksheetDataComponent } from './marksheet-data/marksheet-data.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    imports: [
        CommonModule,
        PagesRoutingModule,
        NgbModule,
        MatchHeightModule,
        NgxDatatableModule
    ],
    exports: [],
    declarations: [
        DashboardComponent,
        MarksheetComponent,
        MarksheetDataComponent
    ],
    providers: [],
})
export class PagesModule { }
