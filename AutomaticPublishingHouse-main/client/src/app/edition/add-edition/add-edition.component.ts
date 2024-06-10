import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-add-edition',
  templateUrl: './add-edition.component.html',
  styleUrls: ['./add-edition.component.scss']
})
export class AddEditionComponent implements OnInit {
  users$: Observable<any>;
  prints$: Observable<any>;
  materials$: Observable<any>;

  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.users$ = this.http.get<any>(`${environment.apiUrl}/Users`);
    this.prints$ = this.http.get<any>(`${environment.apiUrl}/PrintingPress`);
    this.materials$ = this.http.get<any>(`${environment.apiUrl}/Material`);

    this.form = new FormGroup({
      count: new FormControl(),
      materialId: new FormControl(),
      printingPressId: new FormControl(),
      userId: new FormControl()
    });
  }

  onAddEdition() {
    this.http.post(`${environment.apiUrl}/Editions`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/edition'));
  }
}
