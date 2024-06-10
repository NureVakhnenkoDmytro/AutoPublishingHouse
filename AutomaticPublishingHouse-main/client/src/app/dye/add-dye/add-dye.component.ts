import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-add-dye',
  templateUrl: './add-dye.component.html',
  styleUrls: ['./add-dye.component.scss']
})
export class AddDyeComponent implements OnInit {
  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(),
    });
  }

  onAddDye() {
    this.http.post(`${environment.apiUrl}/Dyes`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/dye'));
  }
}
