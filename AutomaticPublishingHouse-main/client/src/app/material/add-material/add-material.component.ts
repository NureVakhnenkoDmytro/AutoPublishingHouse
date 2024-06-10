import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";

@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.scss']
})
export class AddMaterialComponent implements OnInit {
  form: FormGroup;
  dyes$: Observable<any>;

  constructor(private http: HttpClient,
              private router: Router) {
  }

  ngOnInit(): void {
    this.dyes$ = this.http.get<any>(`${environment.apiUrl}/Dyes`);

    this.form = new FormGroup({
      name: new FormControl(),
      content: new FormControl(),
      format: new FormControl(),
      dyeId: new FormControl()
    });
  }

  onAddMaterial() {
    this.http.post(`${environment.apiUrl}/Material`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/material'));
  }
}
