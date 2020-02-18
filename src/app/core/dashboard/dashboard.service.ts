import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class DashboardService {

    constructor(private _http: HttpClient) { }

    getDashboardOverView(filterYear: string, filterSemester: string) {
        return this._http.get(`${environment.apiUrl}/dashboard/overview`, {
            params: {
                filterYear: filterYear,
                filterSemester: filterSemester
            }
        });
    }
}
