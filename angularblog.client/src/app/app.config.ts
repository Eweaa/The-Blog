import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from "@angular/common/http";
import {BrowserAnimationsModule, provideAnimations} from "@angular/platform-browser/animations";
import {provideToastr, ToastrModule} from "ngx-toastr";
import {provideAnimationsAsync} from "@angular/platform-browser/animations/async";
import {addTokenInterceptor} from "./Interceptors/add-token.interceptor";

export const appConfig: ApplicationConfig = {
  providers:
    [
      provideZoneChangeDetection({ eventCoalescing: true }),
      provideRouter(routes),
      provideHttpClient(withInterceptors([addTokenInterceptor])),
      provideAnimations(),
      provideAnimationsAsync(),
      provideToastr(),
    ]
};