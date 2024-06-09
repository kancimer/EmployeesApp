import React from 'react';

const SummaryView = ({ employee, setIsEmployeeViewOpen, setIsEditViewOpen }) => {
    if (!employee) {
        return <div>Please select an employee to see the summary.
            <button className="btn btn-primary" onClick={() => setIsEmployeeViewOpen(false)}>Back</button>
        </div>;
    }

    return (
        <div className="table table-striped">
            <h2>Employee Summary</h2>
            <p><strong>Name:</strong> {employee.name} {employee.surname}</p>
            <img src={employee.employeeImageUrl} alt={employee.name} />
            <p><strong>Gender:</strong> {employee.gender}</p>
            <p><strong>Date of Birth:</strong> {new Date(employee.dateOfBirth).toLocaleDateString()}</p>
            <p><strong>Start Date:</strong> {new Date(employee.startDateOfEmployment).toLocaleDateString()}</p>
            <p><strong>Department:</strong> {employee.department}</p>
            <p><strong>Annual Leave Days:</strong> {employee.annualLeaveDays}</p>

            <p><strong>Days Off:</strong> {employee.daysOff}</p>
            <p><strong>Days of Paid Leave:</strong> {employee.daysOfPaidLeave}</p>
            <button className="btn btn-primary" onClick={() => setIsEmployeeViewOpen(false)}>Back</button>
            <button className="btn btn-primary" onClick={() => setIsEditViewOpen(true)}>Edit</button>
        </div>
    );
};

export default SummaryView;
