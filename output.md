stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at processTicksAndRejections (node:internal/process/task_queues:104:5)
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should handle login errors
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should handle refresh token errors
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

 ❯ test/redux/api/AuthAPI.test.tsx (4 tests | 2 failed) 258ms
   × AuthAPI > useLoginMutation > should return access token and refresh token on successful login 172ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useLoginMutation > should handle login errors 26ms
   × AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing 16ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useRefreshTokenMutation > should handle refresh token errors 31ms
stderr | test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should return all clinics for a patient
An unhandled error occurred processing a request for the endpoint "getAllClinicsPerPatient".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at processTicksAndRejections (node:internal/process/task_queues:104:5)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

 ✓ test/layouts/BaseMenu.test.tsx (7 tests) 192ms
 ✓ test/redux/api/CustomBaseQuery.test.tsx (4 tests) 17ms
stderr | test/redux/api/StudyAPI.test.tsx > StudyAPI > useGetStudyQuery > should handle not found study
An unhandled error occurred processing a request for the endpoint "getStudy".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

stderr | test/redux/api/StudyAPI.test.tsx > StudyAPI > useAddStudyMutation > should add a new study
An unhandled error occurred processing a request for the endpoint "addStudy".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

 ✓ test/hooks/DataTableHook.test.tsx (12 tests) 21ms
 ✓ test/redux/slices/AuthSlice.test.tsx (5 tests) 17ms
stderr | test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should filter clinics by search term
An unhandled error occurred processing a request for the endpoint "getAllClinicsPerPatient".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

 ✓ test/components/DoctorDdataLoader.test.tsx (4 tests) 86ms
stderr | test/redux/api/StudyAPI.test.tsx > StudyAPI > useUpdateStudyMutation > should update a study
An unhandled error occurred processing a request for the endpoint "updateStudy".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

 ✓ test/components/MultiSelectStudy.test.tsx (4 tests) 353ms
 ✓ test/hooks/ToastHook.test.tsx (6 tests) 16ms
stderr | test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useAddClinicPatientMutation > should add a clinic patient association
An unhandled error occurred processing a request for the endpoint "addClinicPatient".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

(node:27767) ExperimentalWarning: localStorage is not available because --localstorage-file was not provided.
(Use `node --trace-warnings ...` to show where the warning was created)
 ✓ test/redux/slices/ToastSlice.test.tsx (9 tests) 20ms
stderr | test/redux/api/StudyAPI.test.tsx > StudyAPI > useDeleteStudyMutation > should delete a study
An unhandled error occurred processing a request for the endpoint "deleteStudy".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

 ✓ test/utils/DoctorAccess.test.tsx (3 tests) 12ms
 ✓ test/redux/slices/DataTableSlice.test.tsx (9 tests) 23ms
stderr | test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useRemoveClinicPatientMutation > should remove a clinic patient association
An unhandled error occurred processing a request for the endpoint "removeClinicPatient".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
    at executeEndpoint (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)

(node:27917) ExperimentalWarning: localStorage is not available because --localstorage-file was not provided.
(Use `node --trace-warnings ...` to show where the warning was created)
(node:27972) ExperimentalWarning: localStorage is not available because --localstorage-file was not provided.
(Use `node --trace-warnings ...` to show where the warning was created)
 ❯ test/redux/api/StudyAPI.test.tsx (7 tests | 6 failed) 30176ms
   × StudyAPI > useGetAllStudiesQuery > should return all studies 5038ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × StudyAPI > useGetAllStudiesQuery > should filter studies by search term 5012ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × StudyAPI > useGetStudyQuery > should return a study by id 5011ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   ✓ StudyAPI > useGetStudyQuery > should handle not found study 69ms
   × StudyAPI > useAddStudyMutation > should add a new study 5010ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × StudyAPI > useUpdateStudyMutation > should update a study 5007ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × StudyAPI > useDeleteStudyMutation > should delete a study 5009ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ✓ test/hooks/DetailAppointmentHook.test.tsx (2 tests) 11ms
(node:28034) ExperimentalWarning: localStorage is not available because --localstorage-file was not provided.
(Use `node --trace-warnings ...` to show where the warning was created)
 ❯ test/main.test.tsx (2 tests | 2 failed) 250ms
   × main.tsx > should render the app when root element exists 200ms
     → Cannot read properties of undefined (reading 'getItem')
   × main.tsx > should throw an error when root element does not exist 46ms
     → expected [Function] to throw error including 'Root element with ID \'root\' was not…' but got 'Cannot read properties of undefined (…'
 ❯ test/redux/api/ClinicPatientAPI.test.tsx (4 tests | 4 failed) 20076ms
   × ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should return all clinics for a patient 5033ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should filter clinics by search term 5007ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × ClinicPatientAPI > useAddClinicPatientMutation > should add a clinic patient association 5009ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
   × ClinicPatientAPI > useRemoveClinicPatientMutation > should remove a clinic patient association 5013ms
     → Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ✓ test/utils/StaticVariables.test.tsx (5 tests) 21ms
(node:28087) ExperimentalWarning: localStorage is not available because --localstorage-file was not provided.
(Use `node --trace-warnings ...` to show where the warning was created)
 ❯ test/utils/ApiPath.test.tsx (3 tests | 1 failed) 35ms
   × ApiPath > API_URL > should export API_URL as a non-empty string 27ms
     → expected 'undefined' to be 'string' // Object.is equality
   ✓ ApiPath > BASE_PATH > should export correct base path enum values 2ms
   ✓ ApiPath > BASE_PATH > should have all required path values 2ms
 ✓ test/components/GlobalToast.test.tsx (3 tests) 88ms

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯ Failed Suites 5 ⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯

 FAIL  test/layouts/BodyDashboard.test.tsx [ test/layouts/BodyDashboard.test.tsx ]
 FAIL  test/routers/admin.test.tsx [ test/routers/admin.test.tsx ]
 FAIL  test/routers/clinic.test.tsx [ test/routers/clinic.test.tsx ]
 FAIL  test/routers/doctor.test.tsx [ test/routers/doctor.test.tsx ]
 FAIL  test/routers/index.test.tsx [ test/routers/index.test.tsx ]
TypeError: Cannot read properties of undefined (reading 'getItem')
 ❯ getTokenFromStorage src/features/auth/utils/TokenManager.tsx:33:36
     31|   refreshToken: string
     32| } => {
     33|   const accessToken = localStorage.getItem("accessToken") ?? ""
       |                                    ^
     34|   const refreshToken = localStorage.getItem("refreshToken") ?? ""
     35|   return { accessToken, refreshToken }
 ❯ src/redux/slices/AuthSlice.tsx:11:22
 ❯ src/redux/api/CustomBaseQuery.tsx:11:1

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[1/54]⎯


⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯ Failed Tests 49 ⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯

 FAIL  test/main.test.tsx > main.tsx > should render the app when root element exists
TypeError: Cannot read properties of undefined (reading 'getItem')
 ❯ getTokenFromStorage src/features/auth/utils/TokenManager.tsx:33:36
     31|   refreshToken: string
     32| } => {
     33|   const accessToken = localStorage.getItem("accessToken") ?? ""
       |                                    ^
     34|   const refreshToken = localStorage.getItem("refreshToken") ?? ""
     35|   return { accessToken, refreshToken }
 ❯ src/redux/slices/AuthSlice.tsx:11:22
 ❯ src/redux/api/CustomBaseQuery.tsx:11:1

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[2/54]⎯

 FAIL  test/main.test.tsx > main.tsx > should throw an error when root element does not exist
AssertionError: expected [Function] to throw error including 'Root element with ID \'root\' was not…' but got 'Cannot read properties of undefined (…'

Expected: "Root element with ID 'root' was not found in the document. Ensure there is a corresponding HTML element with the ID 'root' in your HTML file."
Received: "Cannot read properties of undefined (reading 'getItem')"

 ❯ test/main.test.tsx:73:5
     71|   it("should throw an error when root element does not exist", async () => {
     72|     // The main module execution should throw when root doesn't exist
     73|     await expect(runMainModule()).rejects.toThrow(
       |     ^
     74|       "Root element with ID 'root' was not found in the document. Ensure there is a corresponding HTML element with the ID 'root' in your HTML file.",
     75|     )

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[3/54]⎯

 FAIL  test/utils/ApiPath.test.tsx > ApiPath > API_URL > should export API_URL as a non-empty string
AssertionError: expected 'undefined' to be 'string' // Object.is equality

Expected: "string"
Received: "undefined"

 ❯ test/utils/ApiPath.test.tsx:8:30
      6|     it("should export API_URL as a non-empty string", () => {
      7|       // Verify it's a string
      8|       expect(typeof API_URL).toBe("string")
       |                              ^
      9| 
     10|       // Verify it's not empty

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[4/54]⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:148:43
    146| 
    147|       // Check the final state after the mutation is complete
    148|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    149|       expect(result.current[1].data).toEqual({
    150|         accessToken: "mock-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[5/54]⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:215:43
    213| 
    214|       // Check the final state after the mutation is complete
    215|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    216|       expect(result.current[1].data).toEqual({
    217|         accessToken: "new-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[6/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useGetAllClinicsQuery > should return all clinics for admin
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:183:5
    181| 
    182|   describe("useGetAllClinicsQuery", () => {
    183|     it("should return all clinics for admin", async () => {
       |     ^
    184|       const { result } = renderHook(
    185|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[7/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useGetAllClinicsQuery > should filter clinics by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:205:5
    203|     })
    204| 
    205|     it("should filter clinics by search term", async () => {
       |     ^
    206|       const { result } = renderHook(
    207|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[8/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useGetClinicQuery > should return a clinic by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:230:5
    228| 
    229|   describe("useGetClinicQuery", () => {
    230|     it("should return a clinic by id", async () => {
       |     ^
    231|       const { result } = renderHook(() => useGetClinicQuery(1), { wrapper })
    232| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[9/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useAddClinicMutation > should add a new clinic
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:266:5
    264| 
    265|   describe("useAddClinicMutation", () => {
    266|     it("should add a new clinic", async () => {
       |     ^
    267|       const { result } = renderHook(() => useAddClinicMutation(), { wrapper })
    268| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[10/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useUpdateClinicMutation > should update a clinic
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:301:5
    299| 
    300|   describe("useUpdateClinicMutation", () => {
    301|     it("should update a clinic", async () => {
       |     ^
    302|       const { result } = renderHook(() => useUpdateClinicMutation(), {
    303|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[11/54]⎯

 FAIL  test/redux/api/ClinicAPI.test.tsx > ClinicAPI > useDeleteClinicMutation > should delete a clinic
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAPI.test.tsx:341:5
    339| 
    340|   describe("useDeleteClinicMutation", () => {
    341|     it("should delete a clinic", async () => {
       |     ^
    342|       const { result } = renderHook(() => useDeleteClinicMutation(), {
    343|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[12/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useGetAllClinicAdminsQuery > should return all clinic admins
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:191:5
    189| 
    190|   describe("useGetAllClinicAdminsQuery", () => {
    191|     it("should return all clinic admins", async () => {
       |     ^
    192|       const { result } = renderHook(
    193|         () => useGetAllClinicAdminsQuery({ page: 1, pageSize: 10, search: "" }),

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[13/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useGetAllClinicAdminsQuery > should filter clinic admins by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:204:5
    202|     })
    203| 
    204|     it("should filter clinic admins by search term", async () => {
       |     ^
    205|       const { result } = renderHook(
    206|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[14/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useGetClinicAdminQuery > should return a clinic admin by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:221:5
    219| 
    220|   describe("useGetClinicAdminQuery", () => {
    221|     it("should return a clinic admin by id", async () => {
       |     ^
    222|       const { result } = renderHook(
    223|         () => useGetClinicAdminQuery("admin-id-1"),

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[15/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useAddClinicAdminMutation > should add a new clinic admin
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:257:5
    255| 
    256|   describe("useAddClinicAdminMutation", () => {
    257|     it("should add a new clinic admin", async () => {
       |     ^
    258|       const { result } = renderHook(() => useAddClinicAdminMutation(), {
    259|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[16/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useUpdateClinicAdminMutation > should update a clinic admin
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:290:5
    288| 
    289|   describe("useUpdateClinicAdminMutation", () => {
    290|     it("should update a clinic admin", async () => {
       |     ^
    291|       const { result } = renderHook(() => useUpdateClinicAdminMutation(), {
    292|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[17/54]⎯

 FAIL  test/redux/api/ClinicAdminAPI.test.tsx > ClinicAdminAPI > useDeleteClinicAdminMutation > should delete a clinic admin
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicAdminAPI.test.tsx:325:5
    323| 
    324|   describe("useDeleteClinicAdminMutation", () => {
    325|     it("should delete a clinic admin", async () => {
       |     ^
    326|       const { result } = renderHook(() => useDeleteClinicAdminMutation(), {
    327|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[18/54]⎯

 FAIL  test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should return all clinics for a patient
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicPatientAPI.test.tsx:158:5
    156| 
    157|   describe("useGetAllClinicsPerPatientQuery", () => {
    158|     it("should return all clinics for a patient", async () => {
       |     ^
    159|       const { result } = renderHook(
    160|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[19/54]⎯

 FAIL  test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useGetAllClinicsPerPatientQuery > should filter clinics by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicPatientAPI.test.tsx:180:5
    178|     })
    179| 
    180|     it("should filter clinics by search term", async () => {
       |     ^
    181|       const { result } = renderHook(
    182|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[20/54]⎯

 FAIL  test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useAddClinicPatientMutation > should add a clinic patient association
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicPatientAPI.test.tsx:205:5
    203| 
    204|   describe("useAddClinicPatientMutation", () => {
    205|     it("should add a clinic patient association", async () => {
       |     ^
    206|       const { result } = renderHook(() => useAddClinicPatientMutation(), {
    207|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[21/54]⎯

 FAIL  test/redux/api/ClinicPatientAPI.test.tsx > ClinicPatientAPI > useRemoveClinicPatientMutation > should remove a clinic patient association
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/ClinicPatientAPI.test.tsx:240:5
    238| 
    239|   describe("useRemoveClinicPatientMutation", () => {
    240|     it("should remove a clinic patient association", async () => {
       |     ^
    241|       const { result } = renderHook(() => useRemoveClinicPatientMutation(), {
    242|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[22/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useGetAllDoctorsQuery > should return all doctors for admin
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:206:5
    204| 
    205|   describe("useGetAllDoctorsQuery", () => {
    206|     it("should return all doctors for admin", async () => {
       |     ^
    207|       const { result } = renderHook(
    208|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[23/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useGetAllDoctorsQuery > should filter doctors by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:228:5
    226|     })
    227| 
    228|     it("should filter doctors by search term", async () => {
       |     ^
    229|       const { result } = renderHook(
    230|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[24/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useGetDoctorQuery > should return a doctor by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:253:5
    251| 
    252|   describe("useGetDoctorQuery", () => {
    253|     it("should return a doctor by id", async () => {
       |     ^
    254|       const { result } = renderHook(() => useGetDoctorQuery("doc-id-1"), {
    255|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[25/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useAddDoctorMutation > should add a new doctor
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:294:5
    292| 
    293|   describe("useAddDoctorMutation", () => {
    294|     it("should add a new doctor", async () => {
       |     ^
    295|       const { result } = renderHook(() => useAddDoctorMutation(), { wrapper })
    296| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[26/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useUpdateDoctorMutation > should update a doctor
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:334:5
    332| 
    333|   describe("useUpdateDoctorMutation", () => {
    334|     it("should update a doctor", async () => {
       |     ^
    335|       const { result } = renderHook(() => useUpdateDoctorMutation(), {
    336|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[27/54]⎯

 FAIL  test/redux/api/DoctorAPI.test.tsx > DoctorAPI > useDeleteDoctorMutation > should delete a doctor
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/DoctorAPI.test.tsx:378:5
    376| 
    377|   describe("useDeleteDoctorMutation", () => {
    378|     it("should delete a doctor", async () => {
       |     ^
    379|       const { result } = renderHook(() => useDeleteDoctorMutation(), {
    380|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[28/54]⎯

 FAIL  test/redux/api/MedicalConsultationAPI.test.tsx > MedicalConsultationAPI > useGetAllMedicalConsultationPerDoctorAndClinicQuery > should return all consultations for a doctor and clinic
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/MedicalConsultationAPI.test.tsx:254:5
    252| 
    253|   describe("useGetAllMedicalConsultationPerDoctorAndClinicQuery", () => {
    254|     it("should return all consultations for a doctor and clinic", async () => {
       |     ^
    255|       const { result } = renderHook(
    256|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[29/54]⎯

 FAIL  test/redux/api/MedicalConsultationAPI.test.tsx > MedicalConsultationAPI > useGetAllMedicalConsultationPerDoctorAndClinicQuery > should filter consultations by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/MedicalConsultationAPI.test.tsx:277:5
    275|     })
    276| 
    277|     it("should filter consultations by search term", async () => {
       |     ^
    278|       const { result } = renderHook(
    279|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[30/54]⎯

 FAIL  test/redux/api/MedicalConsultationAPI.test.tsx > MedicalConsultationAPI > useGetAllMedicalConsultationOfPatientQuery > should return all consultations for a patient
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/MedicalConsultationAPI.test.tsx:303:5
    301| 
    302|   describe("useGetAllMedicalConsultationOfPatientQuery", () => {
    303|     it("should return all consultations for a patient", async () => {
       |     ^
    304|       const { result } = renderHook(
    305|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[31/54]⎯

 FAIL  test/redux/api/MedicalConsultationAPI.test.tsx > MedicalConsultationAPI > useGetAllMedicalConsultationOfClinicQuery > should return all consultations for a clinic administrator
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/MedicalConsultationAPI.test.tsx:327:5
    325| 
    326|   describe("useGetAllMedicalConsultationOfClinicQuery", () => {
    327|     it("should return all consultations for a clinic administrator", async () => {
       |     ^
    328|       const { result } = renderHook(
    329|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[32/54]⎯

 FAIL  test/redux/api/MedicalConsultationAPI.test.tsx > MedicalConsultationAPI > useAddMedicalConsultationMutation > should add a new consultation
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/MedicalConsultationAPI.test.tsx:351:5
    349| 
    350|   describe("useAddMedicalConsultationMutation", () => {
    351|     it("should add a new consultation", async () => {
       |     ^
    352|       const { result } = renderHook(() => useAddMedicalConsultationMutation(), {
    353|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[33/54]⎯

 FAIL  test/redux/api/PatientAPI.test.tsx > PatientAPI > useGetPatientsPerClinicQuery > should return all patients for a clinic
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/PatientAPI.test.tsx:197:5
    195| 
    196|   describe("useGetPatientsPerClinicQuery", () => {
    197|     it("should return all patients for a clinic", async () => {
       |     ^
    198|       const { result } = renderHook(
    199|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[34/54]⎯

 FAIL  test/redux/api/PatientAPI.test.tsx > PatientAPI > useGetPatientsPerClinicQuery > should filter patients by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/PatientAPI.test.tsx:219:5
    217|     })
    218| 
    219|     it("should filter patients by search term", async () => {
       |     ^
    220|       const { result } = renderHook(
    221|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[35/54]⎯

 FAIL  test/redux/api/PatientAPI.test.tsx > PatientAPI > useGetPatientQuery > should return a patient by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/PatientAPI.test.tsx:244:5
    242| 
    243|   describe("useGetPatientQuery", () => {
    244|     it("should return a patient by id", async () => {
       |     ^
    245|       const { result } = renderHook(() => useGetPatientQuery("patient-id-1"), {
    246|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[36/54]⎯

 FAIL  test/redux/api/PatientAPI.test.tsx > PatientAPI > useAddPatientMutation > should add a new patient
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/PatientAPI.test.tsx:285:5
    283| 
    284|   describe("useAddPatientMutation", () => {
    285|     it("should add a new patient", async () => {
       |     ^
    286|       const { result } = renderHook(() => useAddPatientMutation(), { wrapper })
    287| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[37/54]⎯

 FAIL  test/redux/api/PatientAPI.test.tsx > PatientAPI > useUpdatePatientMutation > should update a patient
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/PatientAPI.test.tsx:327:5
    325| 
    326|   describe("useUpdatePatientMutation", () => {
    327|     it("should update a patient", async () => {
       |     ^
    328|       const { result } = renderHook(() => useUpdatePatientMutation(), {
    329|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[38/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useGetAllSpecialitiesQuery > should return all specialities
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:176:5
    174| 
    175|   describe("useGetAllSpecialitiesQuery", () => {
    176|     it("should return all specialities", async () => {
       |     ^
    177|       const { result } = renderHook(
    178|         () => useGetAllSpecialitiesQuery({ page: 1, pageSize: 10, search: "" }),

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[39/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useGetAllSpecialitiesQuery > should filter specialities by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:196:5
    194|     })
    195| 
    196|     it("should filter specialities by search term", async () => {
       |     ^
    197|       const { result } = renderHook(
    198|         () =>

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[40/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useGetSpecialityQuery > should return a speciality by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:220:5
    218| 
    219|   describe("useGetSpecialityQuery", () => {
    220|     it("should return a speciality by id", async () => {
       |     ^
    221|       const { result } = renderHook(() => useGetSpecialityQuery(1), { wrapper })
    222| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[41/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useAddSpecialityMutation > should add a new speciality
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:263:5
    261| 
    262|   describe("useAddSpecialityMutation", () => {
    263|     it("should add a new speciality", async () => {
       |     ^
    264|       const { result } = renderHook(() => useAddSpecialityMutation(), {
    265|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[42/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useUpdateSpecialityMutation > should update a speciality
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:301:5
    299| 
    300|   describe("useUpdateSpecialityMutation", () => {
    301|     it("should update a speciality", async () => {
       |     ^
    302|       const { result } = renderHook(() => useUpdateSpecialityMutation(), {
    303|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[43/54]⎯

 FAIL  test/redux/api/SpecialityAPI.test.tsx > SpecialityAPI > useDeleteSpecialityMutation > should delete a speciality
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/SpecialityAPI.test.tsx:342:5
    340| 
    341|   describe("useDeleteSpecialityMutation", () => {
    342|     it("should delete a speciality", async () => {
       |     ^
    343|       const { result } = renderHook(() => useDeleteSpecialityMutation(), {
    344|         wrapper,

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[44/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useGetAllStudiesQuery > should return all studies
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:169:5
    167| 
    168|   describe("useGetAllStudiesQuery", () => {
    169|     it("should return all studies", async () => {
       |     ^
    170|       const { result } = renderHook(
    171|         () => useGetAllStudiesQuery({ page: 1, pageSize: 10, search: "" }),

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[45/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useGetAllStudiesQuery > should filter studies by search term
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:187:5
    185|     })
    186| 
    187|     it("should filter studies by search term", async () => {
       |     ^
    188|       const { result } = renderHook(
    189|         () => useGetAllStudiesQuery({ page: 1, pageSize: 10, search: "blood" }),

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[46/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useGetStudyQuery > should return a study by id
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:208:5
    206| 
    207|   describe("useGetStudyQuery", () => {
    208|     it("should return a study by id", async () => {
       |     ^
    209|       const { result } = renderHook(() => useGetStudyQuery(1), { wrapper })
    210| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[47/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useAddStudyMutation > should add a new study
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:244:5
    242| 
    243|   describe("useAddStudyMutation", () => {
    244|     it("should add a new study", async () => {
       |     ^
    245|       const { result } = renderHook(() => useAddStudyMutation(), { wrapper })
    246| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[48/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useUpdateStudyMutation > should update a study
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:277:5
    275| 
    276|   describe("useUpdateStudyMutation", () => {
    277|     it("should update a study", async () => {
       |     ^
    278|       const { result } = renderHook(() => useUpdateStudyMutation(), { wrapper })
    279| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[49/54]⎯

 FAIL  test/redux/api/StudyAPI.test.tsx > StudyAPI > useDeleteStudyMutation > should delete a study
Error: Test timed out in 5000ms.
If this is a long-running test, pass a timeout value as the last argument or configure it globally with "testTimeout".
 ❯ test/redux/api/StudyAPI.test.tsx:313:5
    311| 
    312|   describe("useDeleteStudyMutation", () => {
    313|     it("should delete a study", async () => {
       |     ^
    314|       const { result } = renderHook(() => useDeleteStudyMutation(), { wrapper })
    315| 

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[50/54]⎯


 Test Files  16 failed | 13 passed (29)
      Tests  49 failed | 83 passed (132)
   Start at  12:28:08
   Duration  91.97s (transform 1.84s, setup 0ms, collect 9.29s, tests 222.67s, environment 25.41s, prepare 5.26s)

# npm audit report

nanoid  <=3.3.17
Severity: high
nanoid: non-secure generators can loop indefinitely with negative size - https://github.com/advisories/GHSA-28wg-ghj8-5hjv
nanoid: custom generators can loop indefinitely when size is zero - https://github.com/advisories/GHSA-2v37-7h3g-55p8
nanoid: Integer Overflow or Wraparound - https://github.com/advisories/GHSA-xwg4-73v4-xw9w
fix available via `npm audit fix`
node_modules/nanoid

postcss  <=8.5.22
Severity: high
PostCSS has XSS via Unescaped </style> in its CSS Stringify Output - https://github.com/advisories/GHSA-qx2v-qp2m-jg93
PostCSS: Arbitrary file read and information disclosure via attacker-controlled sourceMappingURL in CSS comments - https://github.com/advisories/GHSA-6g55-p6wh-862q
PostCSS: incomplete fix of GHSA-6g55-p6wh-862q — attacker-controlled sourceMappingURL reads arbitrary .map files when `from` is unset - https://github.com/advisories/GHSA-fxqj-rqcc-2cmp
PostCSS: Path Traversal in Previous Source Map Auto-Loading (sourceMappingURL) leads to Arbitrary .map File Disclosure - https://github.com/advisories/GHSA-r28c-9q8g-f849
fix available via `npm audit fix`
node_modules/postcss

react-router  6.0.0 - 7.17.0
Severity: high
React Router vulnerable to XSS via Open Redirects - https://github.com/advisories/GHSA-2w69-qvjg-hvjx
React Router has unexpected external redirect via untrusted paths - https://github.com/advisories/GHSA-9jcx-v3wj-wh4m
React Router's vendored turbo-stream v2 allows arbitrary constructor invocation via TYPE_ERROR deserialization leading to Unauth RCE - https://github.com/advisories/GHSA-49rj-9fvp-4h2h
React Router vulnerable to DoS via unbounded path expansion in __manifest endpoint - https://github.com/advisories/GHSA-8x6r-g9mw-2r78
React Router vulnerable to Denial of Service via reflected user input in single-fetch - https://github.com/advisories/GHSA-rxv8-25v2-qmq8
React Router has CSRF issue in Action/Server Action Request Processing - https://github.com/advisories/GHSA-h5cw-625j-3rxh
React Router: Open redirect via backslash in <Link> and useNavigate (CVE-2025-68470 bypass) - https://github.com/advisories/GHSA-wrjc-x8rr-h8h6
React Router: Arbitrary Constructor Injection via deserializeErrors() in React Router SSR Hydration - https://github.com/advisories/GHSA-337j-9hxr-rhxg
React Router: Unauthenticated Denial of Service via Inefficient Route Matching - https://github.com/advisories/GHSA-chx6-hx7r-mcp5
React Router's same-origin redirect with path starting // causes open redirect via protocol-relative URL reinterpretation - https://github.com/advisories/GHSA-2j2x-hqr9-3h42
React Router has stored XSS via unescaped Location header in prerendered redirect HTML - https://github.com/advisories/GHSA-f22v-gfqf-p8f3
React Router SSR XSS in ScrollRestoration - https://github.com/advisories/GHSA-8v8x-cx79-35w7
React Router has XSS Vulnerability - https://github.com/advisories/GHSA-3cgp-3xvw-98x8
fix available via `npm audit fix`
node_modules/react-router
  react-router-dom  7.0.0-pre.0 - 7.11.0
  Depends on vulnerable versions of react-router
  node_modules/react-router-dom

rollup  4.0.0 - 4.58.0
Severity: high
Rollup 4 has Arbitrary File Write via Path Traversal - https://github.com/advisories/GHSA-mw96-cpmx-2vgc
fix available via `npm audit fix`
node_modules/rollup

source-map-js  1.0.0 - 1.2.1
Severity: high
source-map-js allows event-loop denial of service through indexed source-map section offsets - https://github.com/advisories/GHSA-68fv-2mgg-jv7q
fix available via `npm audit fix`
node_modules/source-map-js

vite  <=6.4.2
Severity: high
Vite's server.fs.deny bypassed with /. for files under project root - https://github.com/advisories/GHSA-859w-5945-r5v3
Vite middleware may serve files starting with the same name with the public directory - https://github.com/advisories/GHSA-g4jq-h2w9-997c
Vite's `server.fs` settings were not applied to HTML files - https://github.com/advisories/GHSA-jqfw-vq24-v9c3
vite allows server.fs.deny bypass via backslash on Windows - https://github.com/advisories/GHSA-93m4-6634-74q7
Vite Vulnerable to Path Traversal in Optimized Deps `.map` Handling - https://github.com/advisories/GHSA-4w7w-66w2-5vf9
Vite Vulnerable to Arbitrary File Read via Vite Dev Server WebSocket - https://github.com/advisories/GHSA-p9ff-h696-f583
launch-editor: NTLMv2 hash disclosure via UNC path handling on Windows - https://github.com/advisories/GHSA-v6wh-96g9-6wx3
vite: `server.fs.deny` bypass on Windows alternate paths - https://github.com/advisories/GHSA-fx2h-pf6j-xcff
fix available via `npm audit fix`
node_modules/vite

7 high severity vulnerabilities

To address all issues, run:
  npm audit fix



amarthi-avinash@archlinux wirachain-frontend-main]$ npm test -- test/redux/api/AuthAPI.test.tsx
npm notice run vite-template-redux@0.0.0 test
npm notice run vitest --run test/redux/api/AuthAPI.test.tsx
 Vitest  "deps.inline" is deprecated. If you rely on vite-node directly, use "server.deps.inline" instead. Otherwise, consider using "deps.optimizer.web.include"

 RUN  v3.1.3 /home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at processTicksAndRejections (node:internal/process/task_queues:104:5)
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should handle login errors
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should handle refresh token errors
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: RequestInit: Expected signal ("AbortSignal {}") to be an instance of AbortSignal.
    at Object.webidl.errors.exception (node:internal/deps/undici/undici:4752:14)
    at Object.AbortSignal (node:internal/deps/undici/undici:5010:31)
    at node:internal/deps/undici/undici:13662:41
    at node:internal/deps/undici/undici:5062:16
    at Object.RequestInit (node:internal/deps/undici/undici:5044:21)
    at new Request (node:internal/deps/undici/undici:13009:34)
    at Object.construct (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    at file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
    at baseQueryWithReauth (/home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/src/redux/api/CustomBaseQuery.tsx:40:16)
    at executeRequest (file:///home/pamarthi-avinash/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)

 ❯ test/redux/api/AuthAPI.test.tsx (4 tests | 2 failed) 159ms
   × AuthAPI > useLoginMutation > should return access token and refresh token on successful login 100ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useLoginMutation > should handle login errors 18ms
   × AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing 15ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useRefreshTokenMutation > should handle refresh token errors 13ms

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯ Failed Tests 2 ⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:148:43
    146| 
    147|       // Check the final state after the mutation is complete
    148|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    149|       expect(result.current[1].data).toEqual({
    150|         accessToken: "mock-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[1/2]⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:215:43
    213| 
    214|       // Check the final state after the mutation is complete
    215|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    216|       expect(result.current[1].data).toEqual({
    217|         accessToken: "new-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[2/2]⎯


 Test Files  1 failed (1)
      Tests  2 failed | 2 passed (4)
   Start at  12:33:29
   Duration  2.53s (transform 464ms, setup 657ms, collect 311ms, tests 159ms, environment 757ms, prepare 167ms)

[pamarthi-avinash@archlinux wirachain-frontend-main]$ docker run --rm -v "$PWD:/app" -w /app node:22-bookworm \
  sh -lc 'npm ci && npm test -- test/redux/api/AuthAPI.test.tsx'
permission denied while trying to connect to the docker API at unix:///var/run/docker.sock
[pamarthi-avinash@archlinux wirachain-frontend-main]$ newgrp docker
[pamarthi-avinash@archlinux wirachain-frontend-main]$ id -nG
docker info --format '{{.ServerVersion}}'
docker wheel pamarthi-avinash
29.8.2
[pamarthi-avinash@archlinux wirachain-frontend-main]$ docker run --rm \
  -v "$PWD:/app" \
  -v /app/node_modules \
  -w /app \
  node:22-bookworm \
  sh -lc 'npm ci && npm test -- test/redux/api/AuthAPI.test.tsx'
Unable to find image 'node:22-bookworm' locally
22-bookworm: Pulling from library/node
8cb71386cfcf: Pull complete 
a4edf9c328e8: Pull complete 
610dc773fbd7: Extracting 13 s
610dc773fbd7: Pull complete 
b27643410a32: Extracting 1 s
b27643410a32: Extracting 2 s
b27643410a32: Extracting 3 s
b27643410a32: Extracting 3 s
b27643410a32: Extracting 4 s
b27643410a32: Pull complete 


11fd0fe23a0e: Pull complete 
263f72aebc64: Extracting 1 s
263f72aebc64: Pull complete 


Digest: sha256:0e5f906573693feaa1e21057ebdcfdb5bd5021f050b2dc7c9deceb629c7da2a8
Status: Downloaded newer image for node:22-bookworm





            


added 527 packages, and audited 528 packages in 2m

168 packages are looking for funding
  run `npm fund` for details

34 vulnerabilities (3 low, 3 moderate, 25 high, 3 critical)

To address all issues, run:
  npm audit fix

Run `npm audit` for details.
npm notice
npm notice New major version of npm available! 10.9.9 -> 12.2.0
npm notice Changelog: https://github.com/npm/cli/releases/tag/v12.2.0
npm notice To update run: npm install -g npm@12.2.0
npm notice

> vite-template-redux@0.0.0 test
> vitest --run test/redux/api/AuthAPI.test.tsx

 Vitest  "deps.inline" is deprecated. If you rely on vite-node directly, use "server.deps.inline" instead. Otherwise, consider using "deps.optimizer.web.include"

 RUN  v3.1.3 /app

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: Failed to parse URL from auth/login
    at new Request (node:internal/deps/undici/undici:9928:19)
    at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    ... 4 lines matching cause stack trace ...
    at executeEndpoint (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)
    at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27 {
  [cause]: TypeError: Invalid URL: auth/login
      at new URLImpl (/app/node_modules/whatwg-url/lib/URL-impl.js:20:13)
      at Object.exports.setup (/app/node_modules/whatwg-url/lib/URL.js:54:12)
      at new URL (/app/node_modules/whatwg-url/lib/URL.js:115:22)
      at new Request (node:internal/deps/undici/undici:9926:25)
      at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
      at processTicksAndRejections (node:internal/process/task_queues:103:5)
      at baseQueryWithReauth (/app/src/redux/api/CustomBaseQuery.tsx:40:16)
      at executeRequest (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
      at executeEndpoint (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)
}

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should handle login errors
An unhandled error occurred processing a request for the endpoint "login".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: Failed to parse URL from auth/login
    at new Request (node:internal/deps/undici/undici:9928:19)
    at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    ... 4 lines matching cause stack trace ...
    at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27 {
  [cause]: TypeError: Invalid URL: auth/login
      at new URLImpl (/app/node_modules/whatwg-url/lib/URL-impl.js:20:13)
      at Object.exports.setup (/app/node_modules/whatwg-url/lib/URL.js:54:12)
      at new URL (/app/node_modules/whatwg-url/lib/URL.js:115:22)
      at new Request (node:internal/deps/undici/undici:9926:25)
      at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
      at baseQueryWithReauth (/app/src/redux/api/CustomBaseQuery.tsx:40:16)
      at executeRequest (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
      at executeEndpoint (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27
}

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: Failed to parse URL from auth/refresh
    at new Request (node:internal/deps/undici/undici:9928:19)
    at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    ... 4 lines matching cause stack trace ...
    at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27 {
  [cause]: TypeError: Invalid URL: auth/refresh
      at new URLImpl (/app/node_modules/whatwg-url/lib/URL-impl.js:20:13)
      at Object.exports.setup (/app/node_modules/whatwg-url/lib/URL.js:54:12)
      at new URL (/app/node_modules/whatwg-url/lib/URL.js:115:22)
      at new Request (node:internal/deps/undici/undici:9926:25)
      at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
      at baseQueryWithReauth (/app/src/redux/api/CustomBaseQuery.tsx:40:16)
      at executeRequest (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
      at executeEndpoint (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27
}

stderr | test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should handle refresh token errors
An unhandled error occurred processing a request for the endpoint "refreshToken".
In the case of an unhandled error, no tags will be "provided" or "invalidated". TypeError: Failed to parse URL from auth/refresh
    at new Request (node:internal/deps/undici/undici:9928:19)
    at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
    ... 4 lines matching cause stack trace ...
    at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27 {
  [cause]: TypeError: Invalid URL: auth/refresh
      at new URLImpl (/app/node_modules/whatwg-url/lib/URL-impl.js:20:13)
      at Object.exports.setup (/app/node_modules/whatwg-url/lib/URL.js:54:12)
      at new URL (/app/node_modules/whatwg-url/lib/URL.js:115:22)
      at new Request (node:internal/deps/undici/undici:9926:25)
      at Object.construct (file:///app/node_modules/@mswjs/interceptors/src/interceptors/ClientRequest/utils/recordRawHeaders.ts:185:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/query/fetchBaseQuery.ts:236:21
      at baseQueryWithReauth (/app/src/redux/api/CustomBaseQuery.tsx:40:16)
      at executeRequest (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:287:20)
      at executeEndpoint (file:///app/node_modules/@reduxjs/toolkit/src/query/core/buildThunks.ts:393:33)
      at file:///app/node_modules/@reduxjs/toolkit/src/createAsyncThunk.ts:361:27
}

 ❯ test/redux/api/AuthAPI.test.tsx (4 tests | 2 failed) 231ms
   × AuthAPI > useLoginMutation > should return access token and refresh token on successful login 143ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useLoginMutation > should handle login errors 44ms
   × AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing 16ms
     → expected false to be true // Object.is equality
   ✓ AuthAPI > useRefreshTokenMutation > should handle refresh token errors 17ms

⎯⎯⎯⎯⎯⎯⎯ Failed Tests 2 ⎯⎯⎯⎯⎯⎯⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useLoginMutation > should return access token and refresh token on successful login
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:148:43
    146| 
    147|       // Check the final state after the mutation is complete
    148|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    149|       expect(result.current[1].data).toEqual({
    150|         accessToken: "mock-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[1/2]⎯

 FAIL  test/redux/api/AuthAPI.test.tsx > AuthAPI > useRefreshTokenMutation > should return new tokens when refreshing
AssertionError: expected false to be true // Object.is equality

- Expected
+ Received

- true
+ false

 ❯ test/redux/api/AuthAPI.test.tsx:215:43
    213| 
    214|       // Check the final state after the mutation is complete
    215|       expect(result.current[1].isSuccess).toBe(true)
       |                                           ^
    216|       expect(result.current[1].data).toEqual({
    217|         accessToken: "new-access-token",

⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯[2/2]⎯


 Test Files  1 failed (1)
      Tests  2 failed | 2 passed (4)
   Start at  07:10:27
   Duration  2.96s (transform 499ms, setup 669ms, collect 432ms, tests 231ms, environment 912ms, prepare 220ms)

[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ 
[pamarthi-avinash@archlinux wirachain-frontend-main]$ docker run --rm \
  -v "$PWD:/app" \
  -v wirachain-frontend-node22:/app/node_modules \
  -w /app \
  node:22-bookworm \
  sh -lc 'npm ci && npm test -- test/redux/api/AuthAPI.test.tsx'


