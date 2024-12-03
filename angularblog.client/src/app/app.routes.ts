import {Routes} from '@angular/router';
import {LoginRegisterComponent} from "./Pages/login-register/login-register.component";
import {ContainerComponent} from "./Pages/container/container.component";

export const routes: Routes =
  [
    { path: "", component: ContainerComponent, loadChildren:() => import("./routes").then(m => m.containerRoutes) },
    { path: "Register-login", component: LoginRegisterComponent },
  ];
