import axios from "axios";
import React, { useState } from "react";
import { Alert, Button, Card } from "react-bootstrap";

export default function Form(props) {
  const [descricao, setDescricao] = useState("");
  const [idade, setIdade] = useState("");
  const [especieId, setEspecieId] = useState("");
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  function submit() {
    axios
      .post("http://localhost:4000/link-1", {
        descricao: descricao,
      })
      .then((response) => {
        setDescricao("");
        setIdade("");
        setEspecieId("");
        setSuccess("Registro inserido com sucesso");

        //Reload grid
        props.loadDados();
      })
      .catch((response) => {
        console.log(response);
        setError(response.message);
      });
  }

  return (
    <Card>
      <Card.Header>
        <Card.Title>Gerenciar Àrvores</Card.Title>
      </Card.Header>
      <Card.Body>
        {error && (
          <Alert variant="danger" onClick={() => setError(null)}>
            {error}
          </Alert>
        )}
        {success && (
          <Alert variant="success" onClick={() => setSuccess(null)}>
            {success}
          </Alert>
        )}
        <form>
          <div className="form-group">
            <label>Descrição</label>
            <input
              type="text"
              value={descricao}
              placeholder="Preencha o valor"
              className="form-control"
              onChange={(evt) => setDescricao(evt.target.value)}
            />
          </div>
          <div className="form-group">
            <label>Idade</label>
            <input
              type="text"
              value={idade}
              placeholder="Preencha a Idade"
              className="form-control"
              onChange={(evt) => setIdade(evt.target.value)}
            />
          </div>
          <div className="form-group">
            <label>Espécie</label>
            <select
              value={especieId}
              placeholder="Informe a Espécie"
              className="form-control"
              onChange={(evt) => setEspecieId(evt.target.value)}
            />
          </div>
          <Button variant="primary" type="button" onClick={submit}>
            Cadastrar
          </Button>
        </form>
      </Card.Body>
    </Card>
  );
}
