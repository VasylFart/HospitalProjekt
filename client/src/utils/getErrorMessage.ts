import { ApiError } from '../types';
import { isTypescriptError } from '.';

export const getErrorMessage = (error: unknown): string => {
  if (!isTypescriptError(error)) {
    const apiError = error as ApiError;
    return apiError.response.data.message;
  }
  return error?.message;
};
