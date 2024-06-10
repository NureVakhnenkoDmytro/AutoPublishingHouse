import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {MachinesComponent} from './machines/machines.component';
import {AddMachineComponent} from './machines/add-machine/add-machine.component';
import {MachineDetailsComponent} from './machines/machine-details/machine-details.component';
import {ReportComponent} from './report/report.component';
import {AdminComponent} from './admin/admin.component';
import {RateMapComponent} from './rate-map/rate-map.component';
import {DyeComponent} from './dye/dye.component';
import {AddDyeComponent} from './dye/add-dye/add-dye.component';
import {MaterialComponent} from './material/material.component';
import {AddMaterialComponent} from './material/add-material/add-material.component';
import {PrintComponent} from './print/print.component';
import {AddPrintComponent} from './print/add-print/add-print.component';
import {EditionComponent} from './edition/edition.component';
import {AddEditionComponent} from './edition/add-edition/add-edition.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'dye',
    component: DyeComponent
  },
  {
    path: 'dye/add',
    component: AddDyeComponent
  },
  {
    path: 'material',
    component: MaterialComponent
  },
  {
    path: 'material/add',
    component: AddMaterialComponent
  },
  {
    path: 'print',
    component: PrintComponent
  },
  {
    path: 'print/add',
    component: AddPrintComponent
  },
  {
    path: 'edition',
    component: EditionComponent
  },
  {
    path: 'edition/add',
    component: AddEditionComponent
  },
  {
    path: 'machines',
    component: MachinesComponent
  },
  {
    path: 'machines/add',
    component: AddMachineComponent
  },
  {
    path: 'machines/:id',
    component: MachineDetailsComponent
  },
  {
    path: 'admin',
    component: AdminComponent
  },
  {
    path: 'report',
    component: ReportComponent
  },
  {
    path: 'rate-map',
    component: RateMapComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
