import { Injectable } from '@angular/core';
declare let noty: any;

@Injectable({
  providedIn: 'root'
})
export class NotyService {

constructor() { }

confirm(message: string, okCallBack: () => any) {
  noty.confirm(message, function(e) {
    if (e) {
      okCallBack();
    } else {}
  });
}

success(message: string) {
  noty.success(message);
}

error(message: string) {
  noty.error(message);
}

warning(message: string) {
  noty.warning(message);
}

information(message: string) {
  noty.information(message);
}

}
