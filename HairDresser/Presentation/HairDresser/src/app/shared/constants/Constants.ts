export class Constants {
  public static readonly DECODE_TOKEN_ROLE = 'role';
  public static readonly DECODE_TOKEN_USER_ID = 'unique_name';
  public static readonly LOCAL_STORAGE_AUTH_TOKEN = 'auth_token';
  public static readonly SERVER_BASE_URL = 'https://localhost:44365/api/'; //change to http when docerizing!
  public static readonly LMAP_TITLE_LAYER_URL_TEMPLATE = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
  public static readonly LMAP_TITLE_LAYER_OPTIONS_ATTRIBUTION = '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>';
}
