export class VendorDto {
  constructor(_firstName?:string, _lastName?:string, _companyName?:string) {
    this.firstName = _firstName;
    this.lastName = _lastName;
    this.companyName = _companyName;
  }
  public firstName: string | undefined;
  public lastName: string | undefined;
  public companyName: string | undefined;
}
