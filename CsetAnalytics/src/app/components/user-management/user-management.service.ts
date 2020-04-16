import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { share } from "rxjs/operators";
import { RegisterUser } from 'src/app/models/register-user.model';

@Injectable()

export class UserManagementService {

  constructor(private http: HttpClient, private router: Router) {

  }

  public postCreateUser(user: RegisterUser): Observable<any> {
    return this.http.post('https://localhost:44397/api/user/createuser',user).pipe(share());
  }
}
