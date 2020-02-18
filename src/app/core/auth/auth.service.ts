import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        var formData = new FormData();
        formData.append('UserName', username);
        formData.append('Password', password);
        return this.http.post<any>(`${environment.apiUrl}/users/validatelogin`, formData)
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user.status == true) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user.user));
                    this.currentUserSubject.next(user.user);
                }
                else{
                    this.logout();
                }

                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }

    isLoggedIn(){
        if(localStorage.getItem('currentUser') != undefined){
            return true;
        }
        return false;
    }
}