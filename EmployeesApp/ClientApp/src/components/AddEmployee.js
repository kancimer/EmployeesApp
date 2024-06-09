import React, { useState, useEffect } from 'react';

const AddEmployee = ({ employeeData, onSave, onCancel }) => {
    const [employee, setEmployee] = useState({
        name: '',
        surname: '',
        employeeImageUrl: '',
        gender: '',
        dateOfBirth: '',
        startDateOfEmployment: '',
        isContractPermanent: false,
        contractDuration: '',
        department: '',
        annualLeaveDays: 0,
        daysOff: 0,
        daysOfPaidLeave: 0,
    });

    useEffect(() => {
        if (employeeData) {
            setEmployee(employeeData);
        }
    }, [employeeData]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setEmployee({
            ...employee,
            [name]: type === 'checkbox' ? checked : value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const url = employeeData ? `/api/employees/${employee.id}` : '/api/employees';
        const method = employeeData ? 'PUT' : 'POST';

        const response = await fetch(url, {
            method: method,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(employee),
        });

        if (response.ok) {
            alert(employeeData ? 'Employee updated successfully!' : 'Employee added successfully!');
            onSave();
        } else {
            console.error('Failed to save employee');
            alert('Failed to save employee');
        }
    };

    return (
        <div className="form-group">
            <form onSubmit={handleSubmit}>
                <div className="form-group row">
                    <label>Name:</label>
                    <div className="col-sm-10">
                        <input
                            type="text"
                            name="name"
                            value={employee.name}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Surname:</label>
                    <div className="col-sm-10">
                        <input
                            type="text"
                            name="surname"
                            value={employee.surname}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Image URL:</label>
                    <div className="col-sm-10">
                        <input
                            type="text"
                            name="employeeImageUrl"
                            value={employee.employeeImageUrl}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Gender:</label>
                    <div className="col-sm-10">
                        <input
                            type="text"
                            name="gender"
                            value={employee.gender}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Date of Birth:</label>
                    <div className="col-sm-10">
                        <input
                            type="date"
                            name="dateOfBirth"
                            value={employee.dateOfBirth}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Start Date of Employment:</label>
                    <div className="col-sm-10">
                        <input
                            type="date"
                            name="startDateOfEmployment"
                            value={employee.startDateOfEmployment}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Is Contract Permanent:</label>
                    <div className="col-sm-10">
                        <input
                            type="checkbox"
                            name="isContractPermanent"
                            checked={employee.isContractPermanent}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Contract Duration:</label>
                    <div className="col-sm-10">
                        <input
                            type="date"
                            name="contractDuration"
                            value={employee.contractDuration}
                            onChange={handleChange}
                            required={!employee.isContractPermanent}
                            disabled={employee.isContractPermanent}
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Department:</label>
                    <div className="col-sm-10">
                        <input
                            type="text"
                            name="department"
                            value={employee.department}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Annual Leave Days:</label>
                    <div className="col-sm-10">
                        <input
                            type="number"
                            name="annualLeaveDays"
                            value={employee.annualLeaveDays}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Days Off:</label>
                    <div className="col-sm-10">
                        <input
                            type="number"
                            name="daysOff"
                            value={employee.daysOff}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="form-group row">
                    <label>Days of Paid Leave:</label>
                    <div className="col-sm-10">
                        <input
                            type="number"
                            name="daysOfPaidLeave"
                            value={employee.daysOfPaidLeave}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <button className="btn btn-primary" type="submit">{employeeData ? 'Update Employee' : 'Add Employee'}</button>
                <button className="btn btn-secondary" type="button" onClick={onCancel}>Cancel</button>
            </form>
        </div>
    );
};

export default AddEmployee;
