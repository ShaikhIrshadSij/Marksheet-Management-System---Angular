
import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class NGXToastrService {
    constructor(private _toastr: ToastrService) { }

    typeSuccess(toastrMessage: string) {
        this._toastr.success(toastrMessage, 'Success!');
    }

    typeInfo(toastrMessage: string) {
        this._toastr.info(toastrMessage, 'Info!');
    }

    typeWarning(toastrMessage: string) {
        this._toastr.warning(toastrMessage, 'Warning!');
    }

    typeError(toastrMessage: string) {
        this._toastr.error(toastrMessage, 'Error!');
    }
}