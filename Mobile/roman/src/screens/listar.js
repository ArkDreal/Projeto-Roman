import React, { useState, useEffect, Component } from "react";

import {
    StyleSheet,
    Text,
    View,
    TouchableOpacity,
    Image,
    ImageBackground,
    TextInput,
    Button,
    FlatList
} from "react-native";

import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation } from "@react-navigation/native";

import api from '../services/api'

export default class Projetos extends Component {
    constructor(props)
    super(props) {
        this.state = {
            listaProjetos: [],
        }
    }

    buscarProjetos = async() => {
        const resposta = await api.get('/');
        const dadosApi = resposta.data;
        this.setState({ listaProjetos: dadosApi });
    }

    componentDidMount() {
        this.buscarProjetos();
    }

    render() {
        return (
<view>
{/* Colocar cabeçalho */}

<view style={Styles.mainBody}>
<FlatList 
contentContainerStyle={styles.mainBodyContent}
data={this.state.listaProjetos}
keyExtractor={projeto => projeto.idProjeto}
renderItem={this.renderItem}
/>
</view>
</view>
        );
    }
    renderItem = ({projeto}) => (
<view style={styles.flatItemRow}>
<view style={styles.flatItemContainer}>
<text style={styles.flatItemTitle}>{projeto.Titulo}</text>
<text style={styles.flatiItemInfo}>{projeto.Descricao}</text>
<text style={styles.flatiItemInfo}>{projeto.IdProfessorNavigation.Nome}</text>
<text style={styles.flatiItemInfo}>{projeto.IdTemaNavigation.NomeTema}</text>
</view>
</view>
    )
}

const styles = StyleSheet.create({
    
})