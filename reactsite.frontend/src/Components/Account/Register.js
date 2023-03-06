import React from 'react';
import {Link, NavLink} from "react-router-dom";




function Register() {
    return (

        <div className="container py-5">
            <div className="row">
                <div className="col-md-12">
                    <div className="row justify-content-center">
                        <div className="col-md-10">
                            <span className="anchor"></span>
                            <div className="card card-account card-outline-secondary border border-white">
                                <div className="card-header">
                                    <h3 className="mb-0 text-center paragraphHome text-black">Регистрация</h3>
                                </div>
                                <div className="card-body">
                                    <form >
                                        <div className="form-group">
                                            <input
                                                   className="form-control textbox-dg font-weight-bold text-center"
                                                   placeholder="Имя" type="text"/>
                                        </div>
                                        <div className="form-group">
                                            <input autoComplete="new-password"  placeholder="Пароль"
                                                   className="form-control textbox-dg font-weight-bold text-center"
                                                   type="password"/>
                                        </div>
                                        <div className="form-group">
                                            <input autoComplete="new-password"
                                                   placeholder="Подтвердите пароль"
                                                   className="form-control textbox-dg font-weight-bold text-center"
                                                   type="password"/>
                                        </div>

                                        <button className="btn btn-success btn-lg float-right" type="submit">Отправить
                                        </button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
export default Register;