import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadsService {

  constructor(private _http: HttpClient) { }

  uploadFileToServer(fileData: string | Blob) {
    const formData = new FormData();
    formData.append('file', fileData);
    return this._http.post(`${environment.apiUrl}/excelupload/marksheet`, formData);
  }
}
