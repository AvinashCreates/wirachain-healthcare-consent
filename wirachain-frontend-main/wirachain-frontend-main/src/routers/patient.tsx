import type { RouteObject } from "react-router"
import {
  ConsentManagement,
  DetailAppointment,
  ListAppointment,
  ListClinic,
  Profile,
} from "../features/patient"

const PatientRouter: RouteObject[] = [
  {
    path: "patient/appointment-list",
    children: [
      {
        index: true,
        element: <ListAppointment />,
      },
      {
        path: ":idAppointment",
        element: <DetailAppointment />,
      },
    ],
  },
  {
    path: "patient/clinic-list",
    element: <ListClinic />,
  },
  {
    path: "patient/consent-management",
    element: <ConsentManagement />,
  },
  {
    path: "patient/profile",
    element: <Profile />,
  },
]

export { PatientRouter }
