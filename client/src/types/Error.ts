export interface ApiError {
  response: ErrorResponse;
}

interface ErrorResponse {
  data: ErrorData;
}

interface ErrorData {
  message: string;
  code: string;
}
