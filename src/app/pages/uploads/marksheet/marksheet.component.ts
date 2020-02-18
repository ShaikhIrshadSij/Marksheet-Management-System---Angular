import { Component, OnInit } from '@angular/core';
import { UploadsService } from 'src/app/core/uploads/uploads.service';
import { NGXToastrService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-marksheet',
  templateUrl: './marksheet.component.html',
  styleUrls: ['./marksheet.component.css']
})
export class MarksheetComponent implements OnInit {
  fileData: File = null;

  constructor(
    private _uploadService: UploadsService,
    private _toastr: NGXToastrService
  ) { }

  ngOnInit() {
  }

  onUpload(fileInput: any) {
    this.fileData = <File>fileInput.target.files[0];
  }

  uploadFile() {
    if (this.fileData != null) {
      this._uploadService.uploadFileToServer(this.fileData)
        .subscribe(res => {
          var response: any = res;
          if (response.status == true) {
            this._toastr.typeSuccess(response.message);
          }
          else {
            this._toastr.typeError(response.message);
          }
          this.fileData = null;
        });
    }
    else {
      this._toastr.typeError("Please select a file to upload");
    }
  }


}
