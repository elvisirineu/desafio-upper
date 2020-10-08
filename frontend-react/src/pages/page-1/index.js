import React, { useEffect, useState } from "react";
import axios from "axios";
import Form from "./form";
import Grid from "./grid";

export default function Page1(props) {
  const [dados, setDados] = useState([]); //{id:1, valor:'123'}, {id:2, valor:'89778'}
  const [especies, setEspecies] = useState([]); //{id:1, valor:'123'}, {id:2, valor:'89778'}

  function loadDados() {
    setDados([]);
    axios
      .get("https://localhost:44308/api/v1/arvore")
      .then((response) => {
        console.log(response);
        setDados(response.data);
      })
      .catch((response) => {
        console.log(response);
      });
  }
  function loadEpecies() {
    setEspecies([]);
    axios
      .get("https://localhost:44308/api/v1/especie")
      .then((response) => {
        console.log(response);
        setEspecies(response.data);
      })
      .catch((response) => {
        console.log(response);
      });
  }

  // sera executado apenas um vez, sempre que o componente for montado
  useEffect(() => {
    loadDados();
    loadEpecies();
  }, []);

  return (
    <>
      <Form
        dados={dados}
        loadDados={() => {
          loadDados();
        }}
        loadEpecies={() => {
          loadEpecies();
        }}
      />

      <Grid
        dados={dados}
        loadDados={() => {
          loadDados();
        }}
      />
    </>
  );
}
