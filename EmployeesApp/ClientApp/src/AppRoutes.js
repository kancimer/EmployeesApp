import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import  EmployeesView  from "./components/EmployeesView";

const AppRoutes = [
  {
    index: true,
        element: <EmployeesView />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
