import React from "react";
import axios from "axios";
import { Button, Table } from "react-bootstrap";

export default function Grid(props) {
  function remove(id) {
    axios
      .delete("http://localhost:4000/link-1/" + id)
      .then((response) => {
        props.loadDados();
      })
      .catch((response) => {
        console.log(response);
      });
  }

  return (
    <Table striped hover className="mt-5">
      <thead>
        <tr>
          <th>Àrvore</th>
          <th>Idade</th>
          <th>Espécie</th>
        </tr>
      </thead>
      <tbody>
        {props.dados.map((dado, idx) => {
          return (
            <tr key={idx}>
              <td key="valor">{dado.valor}</td>
              <td key="acao">
                <Button
                  variant="outline-danger"
                  onClick={() => remove(dado.id)}
                >
                  Remover
                </Button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
}
