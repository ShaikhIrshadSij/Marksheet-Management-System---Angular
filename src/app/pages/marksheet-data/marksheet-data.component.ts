import { Component, OnInit } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { MarksheetDataService } from 'src/app/core/marksheet-data/marksheet-data.service';

@Component({
  selector: 'app-marksheet-data',
  templateUrl: './marksheet-data.component.html',
  styleUrls: ['./marksheet-data.component.css']
})
export class MarksheetDataComponent implements OnInit {

  page = {
    limit: 10,
    count: 0,
    offset: 0,
    orderBy: 'ApprovedTime',
    orderDir: 'desc',
    search: ""
  };

  rows: Object[];

  columns = [
    { name: 'EnrollementNo' },
    { name: 'StatementNo' },
    { name: 'Year' },
    { name: 'Month' },
    { name: 'Semester' },
    { name: 'ApprovedTime' },
    { name: 'DisapprovedTime' },
    { name: 'IsApproved' },
    { name: 'MarksheetId' },
  ];

  constructor(private _marksheetDataService: MarksheetDataService) { }

  ngOnInit() {
    this.pageCallback({ offset: 0 });
  }

  pageCallback(pageInfo: { count?: number, pageSize?: number, limit?: number, offset?: number }) {
    this.page.offset = pageInfo.offset;
    this.reloadTable();
  }

  sortCallback(sortInfo: { sorts: { dir: string, prop: string }[], column: {}, prevValue: string, newValue: string }) {
    this.page.orderDir = sortInfo.sorts[0].dir;
    this.page.orderBy = sortInfo.sorts[0].prop;
    this.reloadTable();
  }

  searchCallBack(searchFilter) {
    this.page.search = searchFilter.target.value.toLowerCase();
    this.reloadTable();
  }

  reloadTable() {
    const params = new HttpParams()
      .set('orderColumn', `${this.page.orderBy}`)
      .set('orderDir', `${this.page.orderDir}`)
      .set('pageNumber', `${this.page.offset}`)
      .set('pageSize', `${this.page.limit}`)
      .set('searchFilter', `${this.page.search}`);

    this._marksheetDataService.getMarksheetData(params).subscribe((res) => {
      var data: any = res;
      this.page.count = data.recordsFiltered == data.count ? data.count : data.recordsFiltered;
      this.rows = data.rows;
    });
  }
}
