import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {LoginComponent} from './login/login.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS, HttpClient} from '@angular/common/http';
import {HeaderComponent} from './header/header.component';
import {RegisterComponent} from './register/register.component';
import {AuthInterceptor} from './helpers/auth.interceptor';
import {MachinesComponent} from './machines/machines.component';
import {MachineDetailsComponent} from './machines/machine-details/machine-details.component';
import {AddMachineComponent} from './machines/add-machine/add-machine.component';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {ReportComponent} from './report/report.component';
import {AdminComponent} from './admin/admin.component';
import {RateMapComponent} from './rate-map/rate-map.component';
import {GoogleChartsModule} from 'angular-google-charts';
import { DyeComponent } from './dye/dye.component';
import { MaterialComponent } from './material/material.component';
import { AddMaterialComponent } from './material/add-material/add-material.component';
import { PrintComponent } from './print/print.component';
import { AddPrintComponent } from './print/add-print/add-print.component';
import { AddDyeComponent } from './dye/add-dye/add-dye.component';
import { EditionComponent } from './edition/edition.component';
import { AddEditionComponent } from './edition/add-edition/add-edition.component';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    RegisterComponent,
    MachinesComponent,
    MachineDetailsComponent,
    AddMachineComponent,
    ReportComponent,
    AdminComponent,
    RateMapComponent,
    DyeComponent,
    MaterialComponent,
    AddMaterialComponent,
    PrintComponent,
    AddPrintComponent,
    AddDyeComponent,
    EditionComponent,
    AddEditionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    GoogleChartsModule.forRoot({mapsApiKey: 'AIzaSyBL4bREvpGuhrkcLeaEgBM5I_cdlKMJRlM'}),
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    }),
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
