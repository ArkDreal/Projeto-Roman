import * as React from 'react';
import { View, Text, Button } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import {
    createDrawerNavigator,
    DrawerContentScrollView,
    DrawerItemList,
    DrawerItem,
} from '@react-navigation/drawer';

const Drawer = createDrawerNavigator();

import Listar from '../screens/listar'
// import Cadastrar from '../screens/cadastrar'

export default function Main() {
    return (
            <Drawer.Navigator
                initialRouteName="Listar"
                screenOptions={{
                    drawerHideStatusBarOnOpen:true,
                    drawerStatusBarAnimation:'fade',
                    drawerStyle:{
                        backgroundColor: "#1D1136",
                        width: 240,
                    },
                    drawerContentStyle:{
                        alignContent: "center"
                    },
                    drawerLabelStyle:{
                        textAlign: 'center',
                        color: '#FFF'
                    }
                    
                }}
            >
                <Drawer.Screen name="Listar" component={Listar} />
                {/* <Drawer.Screen name="Cadastrar" component={Cadastrar} /> */}
            </Drawer.Navigator>
    )
}