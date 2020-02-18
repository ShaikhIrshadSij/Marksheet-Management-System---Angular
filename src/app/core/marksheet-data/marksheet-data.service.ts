import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class MarksheetDataService {

    constructor(private _http: HttpClient) { }

    getMarksheetData(params: HttpParams) {
        return this._http.get(`${environment.apiUrl}/marksheets`, { params });
    }
}
