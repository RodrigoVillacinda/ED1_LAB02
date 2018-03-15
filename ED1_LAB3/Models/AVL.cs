using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ED1_LAB3.Models
{
    public class AVL<T> where T : IComparable<T>
    {

        public T Valor;
        public AVL<T> Izquiero;
        public AVL<T> Derecho;
        public AVL<T> Raiz;
        public int altura;

        //Instertar
        public AVL<T> Insertar(T value, AVL<T> root)
        {
            AVL<T> Temp = new AVL<T>();
            Temp.Valor = value;
            Temp.Derecho = null;
            Temp.Izquiero = null;

            if (root==null)
            {
                root = Temp;
            }

            else if (value.CompareTo(root.Valor) <- 1)
                {
                    root.Izquiero = Insertar(value, root.Izquiero);
                    //me voy a la izquierda
                }
            else if (value.CompareTo(root.Valor) > 1)
                {
                    
                        root.Derecho = Insertar(value, root.Derecho);
                        //me voy a la derecha
                    
                }

            if (  Alturas(root.Izquiero) - Alturas(Raiz.Derecho) == 2 )
            {
                if ( value.CompareTo(root.Izquiero.Valor) < -1 ) //value < root.izquiero.valor
                {
                    root = RotacionIzquierdaSimple(root);
                }
                else
                {
                    root = RotacionIzquierdaDoble(root);
                }

            }

            if (Alturas(root.Derecho) - Alturas(Raiz.Izquiero) == 2)
            {
                if (value.CompareTo(root.Derecho.Valor) > 1) //value < root.izquiero.valor
                {
                    root = RotacionDerechaSimple(root);
                }
                else
                {
                    root = RotacionDerechaDoble(root);
                }

            }

            root.altura = Max( Alturas(root.Izquiero), Alturas(root.Derecho) ) + 1;
            return root; 
        }
        //Fin insertar

        //Eliminar
        AVL<T> nDelete, nP;
        public AVL<T> Eliminar(T VaElimina, AVL<T> root)
        {
            if (root!=null)
            {

                if (VaElimina.CompareTo(root.Valor) < -1) //value < root.valor
                {
                    nDelete = root;
                    Eliminar(VaElimina, root.Izquiero);
                }

                else
                {
                    if (VaElimina.CompareTo(root.Valor) >1)
                    {
                        nDelete = root;
                        Eliminar(VaElimina, root.Derecho);
                    }
                    else
                    {
                        //Eliminamos

                        AVL<T> NodoDelete = Raiz;
                        if (NodoDelete.Derecho==null)
                        {
                            Raiz = NodoDelete.Izquiero;

                            if ( Alturas(nDelete.Izquiero) - Alturas(nDelete.Derecho) ==2  )
                            {
                                if (VaElimina.CompareTo(nDelete.Valor ) <-1)
                                {
                                    nP = RotacionIzquierdaSimple(nDelete);
                                   
                                }
                                else
                                {
                                    nP = RotacionDerechaSimple(nDelete);
                                }
                            }
                            if ( Alturas(nDelete.Derecho) - Alturas(nDelete.Izquiero) == 2 )
                            {
                                if (VaElimina.CompareTo(nDelete.Derecho.Valor) > 1 )
                                {
                                    nDelete = RotacionDerechaSimple(nDelete);
                                    
                                }
                                else
                                {
                                    nDelete = RotacionDerechaDoble(nDelete);
                                    nP = RotacionDerechaSimple(nDelete);
                                }
                            }

                        }

                        else
                        {

                            if (NodoDelete.Izquiero==null)
                            {
                                root = NodoDelete.Derecho;
                            }
                            else
                            {
                                if ( Alturas(root.Izquiero) - Alturas(root.Derecho) > 0 )
                                {
                                    AVL<T> Naux = null;
                                    AVL<T> AUX = root.Izquiero;
                                    bool bandera = false;
                                    while (AUX.Derecho!=null)
                                    {
                                        Naux = AUX;
                                        AUX = AUX.Derecho;
                                        bandera = true;
                                    }
                                    root.Valor = AUX.Valor;
                                    NodoDelete = AUX;
                                    if (bandera==true)
                                    {
                                        Naux.Derecho = AUX.Izquiero;
                                    }
                                    else
                                    {
                                        root.Izquiero = AUX.Izquiero;
                                    }
                                }
                                else
                                {
                                    if ( Alturas(root.Derecho) - Alturas(root.Izquiero ) > 0)
                                    {
                                        AVL<T> Naux = null;
                                        AVL<T> AUX = root.Derecho;
                                        bool bandera = false;
                                        while (AUX.Izquiero!=null)
                                        {
                                            Naux = AUX;
                                            AUX = AUX.Izquiero;
                                            bandera = true;
                                        }
                                        root.Valor = AUX.Valor;
                                        NodoDelete = AUX;
                                        if (bandera==true)
                                        {
                                            Naux.Izquiero = AUX.Derecho;

                                        }
                                        else
                                        {
                                            root.Derecho = AUX.Derecho;
                                        }

                                    }
                                    else
                                    {
                                        if (Alturas(root.Derecho) - Alturas(root.Izquiero) == 0)
                                        {
                                            AVL<T> Naux = null;
                                            AVL<T> AUX = root.Izquiero;
                                            bool bandera = false;
                                            while (AUX.Derecho!=null)
                                            {
                                                Naux = AUX;
                                                AUX = AUX.Derecho;
                                                bandera = true;
                                            }
                                            root.Valor = AUX.Valor;
                                            NodoDelete = AUX;
                                            if (bandera==true)
                                            {
                                                Naux.Derecho = AUX.Izquiero;

                                            }
                                            else
                                            {
                                                root.Izquiero = AUX.Izquiero;
                                            }
                                        }
                                    }
                                }
                            }

                        }

                        //fin eliminamos
                    }

                }



            }
            return nP; 
        }
        //Fin eliminar


        //Altura
        private static int Max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        private static int Alturas(AVL<T> R)
        {
            return R == null ? -1 : R.altura;
        }
        //Fin altura


        //ROTACIONES
        private static AVL<T> RotacionIzquierdaSimple(AVL<T> H)
        {
            AVL<T> NH = H.Izquiero; //
            H.Izquiero = NH.Derecho;
            NH.Derecho = H;
            H.altura = Max( Alturas(H.Izquiero) , Alturas(H.Derecho) ) + 1;
            NH.altura = Max( Alturas(NH.Izquiero) , H.altura ) + 1;
            return NH;
        }

        private static AVL<T> RotacionDerechaSimple(AVL<T> NH)
        {
            AVL<T> H = NH.Derecho;
            NH.Derecho = H.Izquiero;
            H.Izquiero = NH;
            NH.altura = Max( Alturas(NH.Izquiero), Alturas(NH.Derecho) ) + 1;
            H.altura = Max( Alturas(H.Derecho), NH.altura ) + 1;
            return H;

        }

        private static AVL<T> RotacionIzquierdaDoble(AVL<T> H)
        {
            H.Izquiero = RotacionDerechaSimple(H.Izquiero);
            return RotacionIzquierdaSimple(H);
        }

        private static AVL<T> RotacionDerechaDoble(AVL<T> NH)
        {
            NH.Derecho = RotacionIzquierdaSimple(NH.Derecho);
            return RotacionDerechaSimple(NH);
        }
        //FIN ROTACIONES
    }


    public class Pais : IComparable<Pais>
    {

        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public int  NoPartido { get; set; }
        public DateTime FechaPartido { get; set; }
        public string Estadio { get; set; }
        public string Grupo { get; set; }

        public int CompareTo(Pais other)
        {
            return this.NoPartido.CompareTo(other.NoPartido);
        }
        

    }

  


}