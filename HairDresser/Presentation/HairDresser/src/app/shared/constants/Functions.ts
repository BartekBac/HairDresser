export class Functions {
  public static copyObject(obj: any): any {
    return JSON.parse(JSON.stringify(obj));
  }
}
