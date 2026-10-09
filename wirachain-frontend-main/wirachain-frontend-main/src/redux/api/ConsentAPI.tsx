import { createApi } from "@reduxjs/toolkit/query/react"
import type { GrantConsentRequest, PatientConsent } from "../../features/patient/types/Consent"
import { baseQueryWithReauth } from "./CustomBaseQuery"

export const consentApi = createApi({
  reducerPath: "consentApi",
  baseQuery: baseQueryWithReauth,
  tagTypes: ["Consent"],
  endpoints: builder => ({
    getMyConsents: builder.query<PatientConsent[], void>({
      query: () => ({
        url: "consents",
        method: "GET",
      }),
      providesTags: result =>
        result
          ? [
              ...result.map(({ id }) => ({
                type: "Consent" as const,
                id,
              })),
              { type: "Consent", id: "LIST" },
            ]
          : [{ type: "Consent", id: "LIST" }],
    }),

    grantConsent: builder.mutation<PatientConsent, GrantConsentRequest>({
      query: body => ({
        url: "consents",
        method: "POST",
        body,
      }),
      invalidatesTags: [{ type: "Consent", id: "LIST" }],
    }),

    revokeConsent: builder.mutation<void, string>({
      query: consentId => ({
        url: `consents/${consentId}`,
        method: "DELETE",
      }),
      invalidatesTags: [{ type: "Consent", id: "LIST" }],
    }),
  }),
})

export const {
  useGetMyConsentsQuery,
  useGrantConsentMutation,
  useRevokeConsentMutation,
} = consentApi
